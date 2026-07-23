using CodeWorldEducation.Application.Abstraction.Services;
using CodeWorldEducation.Application.Features.Endpoints.Queries.GetAllEndpoints;
using CodeWorldEducation.Application.UnitOfWorks;
using CodeWorldEducation.Domain.Entities;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeWorldEducation.Persistence.Services
{
    public class AuthorizationEndpointService : IAuthorizationEndpointService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<AuthorizationEndpointService> _logger;

        public AuthorizationEndpointService(IUnitOfWork unitOfWork, ILogger<AuthorizationEndpointService> logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        public async Task<List<GetAllAuthorizationEndpointsQueryResponse>> GetAllAsync()
        {
            var endpoints = await _unitOfWork.EndpointRepository.GetAllWithRolesAsync();

            _logger.LogInformation(
           "All authorization endpoints retrieved. Count: {Count} | Time: {Time}",
           endpoints.Count,
           DateTime.UtcNow);

            return endpoints.Select(x => new GetAllAuthorizationEndpointsQueryResponse
            {
                Code = x.Code,
                Definition = x.Definition,
                HttpMethod = x.HttpMethod,
                Controller = x.Route,
                ActionType = x.Menu,
                Roles = x.EndpointRoles
                    .Select(r => r.RoleName)
                    .ToList()
            }).ToList();
        }

        public async Task AssignRolesAsync(string endpointCode, List<string> roles)
        {
            var endpoint = await _unitOfWork.EndpointRepository.GetAsync(x => x.Code == endpointCode);

            if (endpoint == null)
                throw new KeyNotFoundException($"Endpoint '{endpointCode}' not found.");

            // Delete old role assignments
            var existingRoles = await _unitOfWork.EndpointRoleRepository
            .GetAllAsync(x => x.EndpointId == endpoint.Id);

            foreach (var role in existingRoles)
            {
                _unitOfWork.EndpointRoleRepository.Delete(role);
            }

            // Add new role assignments
            foreach (var role in roles.Distinct())
            {
                await _unitOfWork.EndpointRoleRepository.AddAsync(new EndpointRole
                {
                    EndpointId = endpoint.Id,
                    RoleName = role,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                });
            }

            await _unitOfWork.SaveChangesAsync();

            _logger.LogInformation(
           "Endpoint roles assigned. Code: {Code} | " +
           "NewRoles: {NewRoles} | Time: {Time}",
           endpointCode,
           string.Join(", ", roles),
           DateTime.UtcNow);
        }
    }
}
