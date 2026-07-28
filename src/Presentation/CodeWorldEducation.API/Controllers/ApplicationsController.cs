using CodeWorldEducation.Application.Common.Applications;
using CodeWorldEducation.Application.Features.Applications.Commands.Approve;
using CodeWorldEducation.Application.Features.Applications.Commands.Create;
using CodeWorldEducation.Application.Features.Applications.Commands.Reject;
using CodeWorldEducation.Application.Features.Applications.Queries.GetAll;
using CodeWorldEducation.Application.Features.Applications.Queries.GetById;
using CodeWorldEducation.Domain.Enums;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CodeWorldEducation.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicationsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ApplicationsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // Public — müraciət göndər
        [HttpPost]
        public async Task<IActionResult> Create([FromForm] CreateApplicationDto dto)
        {
            var response = await _mediator.Send(
                new CreateApplicationCommandRequest { Dto = dto });
            return Ok(response);
        }
    }
}