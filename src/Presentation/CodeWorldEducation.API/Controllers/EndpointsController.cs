using CodeWorldEducation.Application.Features.Endpoints.Commands.AssignRolesToEndpoint;
using CodeWorldEducation.Application.Features.Endpoints.Queries.GetAllEndpoints;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CodeWorldEducation.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EndpointsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public EndpointsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _mediator.Send(new GetAllAuthorizationEndpointsQueryRequest());

            return Ok(result);
        }

        [HttpPost("assign-roles")]
        public async Task<IActionResult> AssignRoles(AssignRolesToEndpointCommandRequest request)
        {
            var result = await _mediator.Send(request);

            return Ok(result);
        }
    }
}
