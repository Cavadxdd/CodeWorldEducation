using CodeWorldEducation.Application.UnitOfWorks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeWorldEducation.Application.Security
{
    public class EndpointPermissionHandler
        : AuthorizationHandler<EndpointPermissionRequirement>
    {
        private readonly IUnitOfWork _unitOfWork;

        public EndpointPermissionHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        protected override async Task HandleRequirementAsync(
            AuthorizationHandlerContext context,
            EndpointPermissionRequirement requirement)
        {
            var httpContext = context.Resource as HttpContext;

            if (httpContext == null)
                return;

            var endpoint = httpContext.GetEndpoint();

            if (endpoint == null)
                return;

            var controllerName = endpoint.Metadata
            .GetMetadata<ControllerActionDescriptor>()?
            .ControllerName;

            var actionName = endpoint.Metadata
                .GetMetadata<ControllerActionDescriptor>()?
                .ActionName;

            if (controllerName == null || actionName == null)
                return;

            var endpointCode = $"{controllerName}.{actionName}";

            var dbEndpoint = await _unitOfWork.EndpointRepository
            .GetAsync(x => x.Code == endpointCode);

            if (dbEndpoint == null)
                return;

            var endpointRoles = await _unitOfWork.EndpointRoleRepository
            .GetAllAsync(x => x.EndpointId == dbEndpoint.Id);

            if (!endpointRoles.Any())
            {
                context.Succeed(requirement);
                return;
            }

            var userRoles = context.User.Claims
            .Where(x => x.Type == System.Security.Claims.ClaimTypes.Role)
            .Select(x => x.Value);

            if (endpointRoles.Any(x => userRoles.Contains(x.RoleName)))
            {
                context.Succeed(requirement);
            }


        }
    }
}
