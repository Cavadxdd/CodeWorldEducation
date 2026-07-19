using CodeWorldEducation.Application.Features.Roles.Commands.CreateRole;
using CodeWorldEducation.Application.Features.Roles.Commands.DeleteRole;
using CodeWorldEducation.Application.Features.Roles.Commands.UpdateRole;
using CodeWorldEducation.Application.Features.Roles.Queries.GetAllRoles;
using CodeWorldEducation.Application.Features.Roles.Commands.AssignRole;
using CodeWorldEducation.Application.Features.Roles.Queries.GetUserRoles;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CodeWorldEducation.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RolesController : ControllerBase
{
    private readonly IMediator _mediator;

    public RolesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var response = await _mediator.Send(new GetAllRolesQueryRequest());
        return Ok(response);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateRoleCommandRequest request)
    {
        var response = await _mediator.Send(request);
        return Ok(response);
    }

    [HttpPut]
    public async Task<IActionResult> Update(UpdateRoleCommandRequest request)
    {
        var response = await _mediator.Send(request);
        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(string id)
    {
        var response = await _mediator.Send(new DeleteRoleCommandRequest { Id = id });
        return Ok(response);
    }
	[HttpPost("assign-role")]
	public async Task<IActionResult> AssignRole(AssignRoleCommandRequest request)
	{
		var response = await _mediator.Send(request);
		return Ok(response);
	}

	[HttpGet("/api/users/{id}/roles")]
	public async Task<IActionResult> GetUserRoles([FromRoute] string id)
	{
		var response = await _mediator.Send(new GetUserRolesQueryRequest { UserId = id });
		return Ok(response);
	}
}