using CodeWorldEducation.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace CodeWorldEducation.Application.Features.Roles.Commands.UpdateRole;

public class UpdateRoleCommandHandler : IRequestHandler<UpdateRoleCommandRequest, UpdateRoleCommandResponse>
{
    private readonly RoleManager<AppRole> _roleManager;

    public UpdateRoleCommandHandler(RoleManager<AppRole> roleManager)
    {
        _roleManager = roleManager;
    }

    public async Task<UpdateRoleCommandResponse> Handle(
        UpdateRoleCommandRequest request,
        CancellationToken cancellationToken)
    {
        var role = await _roleManager.FindByIdAsync(request.Id);
        if (role == null)
            return new UpdateRoleCommandResponse
            {
                Success = false,
                Message = "Rol tapılmadı."
            };

        if (await _roleManager.RoleExistsAsync(request.NewName))
            return new UpdateRoleCommandResponse
            {
                Success = false,
                Message = "Bu ad ilə rol artıq mövcuddur."
            };

        role.Name = request.NewName;
        var result = await _roleManager.UpdateAsync(role);

        if (!result.Succeeded)
            return new UpdateRoleCommandResponse
            {
                Success = false,
                Message = string.Join(", ", result.Errors.Select(e => e.Description))
            };

        return new UpdateRoleCommandResponse
        {
            Success = true,
            Message = "Rol uğurla yeniləndi."
        };
    }
}