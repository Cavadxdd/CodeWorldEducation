using CodeWorldEducation.Application.Features.Applications.Commands.Approve;
using CodeWorldEducation.Application.Features.Applications.Commands.Reject;
using CodeWorldEducation.Application.Features.Applications.Queries.GetAll;
using CodeWorldEducation.Application.Features.Applications.Queries.GetById;
using CodeWorldEducation.Domain.Enums;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace CodeWorldEducation.API.Controllers
{
    [Route("api/admin/applications")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class AdminApplicationsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AdminApplicationsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET /api/admin/applications?type=0&status=0
        [HttpGet]
        public async Task<IActionResult> GetAll(
            [FromQuery] ApplicantType? type,
            [FromQuery] ApplicationStatus? status)
        {
            var response = await _mediator.Send(
                new GetAllApplicationsQueryRequest { Type = type, Status = status });
            return Ok(response);
        }

        // GET /api/admin/applications/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var response = await _mediator.Send(
                new GetApplicationByIdQueryRequest { Id = id });
            return Ok(response);
        }

        // PATCH /api/admin/applications/{id}/approve
        [HttpPatch("{id}/approve")]
        public async Task<IActionResult> Approve(int id)
        {
            var reviewedBy = User.FindFirstValue(ClaimTypes.Email) ?? "Admin";
            var response = await _mediator.Send(
                new ApproveApplicationCommandRequest { Id = id, ReviewedBy = reviewedBy });
            return Ok(response);
        }

        // PATCH /api/admin/applications/{id}/reject
        [HttpPatch("{id}/reject")]
        public async Task<IActionResult> Reject(int id)
        {
            var reviewedBy = User.FindFirstValue(ClaimTypes.Email) ?? "Admin";
            var response = await _mediator.Send(
                new RejectApplicationCommandRequest { Id = id, ReviewedBy = reviewedBy });
            return Ok(response);
        }
    }
}