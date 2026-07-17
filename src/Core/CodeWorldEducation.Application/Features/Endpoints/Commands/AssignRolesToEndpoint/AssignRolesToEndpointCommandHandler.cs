using CodeWorldEducation.Application.Abstraction.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeWorldEducation.Application.Features.Endpoints.Commands.AssignRolesToEndpoint
{
    public class AssignRolesToEndpointCommandHandler
        : IRequestHandler<AssignRolesToEndpointCommandRequest, AssignRolesToEndpointCommandResponse>
    {
        private readonly IAuthorizationEndpointService _authorizationEndpointService;

        public AssignRolesToEndpointCommandHandler(
            IAuthorizationEndpointService authorizationEndpointService)
        {
            _authorizationEndpointService = authorizationEndpointService;
        }

        public async Task<AssignRolesToEndpointCommandResponse> Handle(
            AssignRolesToEndpointCommandRequest request,
            CancellationToken cancellationToken)
        {
            await _authorizationEndpointService.AssignRolesAsync(
                request.EndpointCode,
                request.Roles);

            return new AssignRolesToEndpointCommandResponse
            {
                Success = true
            };
        }
    }
}
