using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeWorldEducation.Application.Features.Endpoints.Commands.AssignRolesToEndpoint
{
    public class AssignRolesToEndpointCommandRequest
        : IRequest<AssignRolesToEndpointCommandResponse>
    {
        public string EndpointCode { get; set; } = null!;
        public List<string> Roles { get; set; } = new();
    }
}
