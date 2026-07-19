using CodeWorldEducation.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace CodeWorldEducation.Application.Features.Roles.Commands.DeleteRole;

public class DeleteRoleCommandHandler : IRequestHandler<DeleteRoleCommandRequest, DeleteRoleCommandResponse>
{
    private readonly RoleManager<AppRole> _roleManager;
    private readonly UserManager<AppUser> _userManager;

    public DeleteRoleCommandHandler(RoleManager<AppRole> roleManager, UserManager<AppUser> userManager)
    {
        _roleManager = roleManager;
        _userManager = userManager;
    }

    public async Task<DeleteRoleCommandResponse> Handle(
        DeleteRoleCommandRequest request,
        CancellationToken cancellationToken)
    {
        var role = await _roleManager.FindByIdAsync(request.Id);
        if (role == null)
            return new DeleteRoleCommandResponse
            {
                Success = false,
                Message = "Rol tapılmadı."
            };

        var usersInRole = await _userManager.GetUsersInRoleAsync(role.Name!);
        if (usersInRole.Any())
            return new DeleteRoleCommandResponse
            {
                Success = false,
                Message = "Bu rol istifadəçilərə təyin edilib, silinə bilməz."
            };

        var result = await _roleManager.DeleteAsync(role);

        if (!result.Succeeded)
            return new DeleteRoleCommandResponse
            {
                Success = false,
                Message = string.Join(", ", result.Errors.Select(e => e.Description))
            };

        return new DeleteRoleCommandResponse
        {
            Success = true,
            Message = "Rol uğurla silindi."
        };
    }
}