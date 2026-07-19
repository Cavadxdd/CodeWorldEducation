using CodeWorldEducation.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace CodeWorldEducation.Application.Features.Roles.Commands.CreateRole;

public class CreateRoleCommandHandler : IRequestHandler<CreateRoleCommandRequest, CreateRoleCommandResponse>
{
    private readonly RoleManager<AppRole> _roleManager;

    public CreateRoleCommandHandler(RoleManager<AppRole> roleManager)
    {
        _roleManager = roleManager;
    }

    public async Task<CreateRoleCommandResponse> Handle(
        CreateRoleCommandRequest request,
        CancellationToken cancellationToken)
    {
        if (string.IsNullOrWhiteSpace(request.Name))
            return new CreateRoleCommandResponse
            {
                Success = false,
                Message = "Rol adı boş ola bilməz."
            };

        if (await _roleManager.RoleExistsAsync(request.Name))
            return new CreateRoleCommandResponse
            {
                Success = false,
                Message = "Bu ad ilə rol artıq mövcuddur."
            };

        var role = new AppRole(request.Name);
        var result = await _roleManager.CreateAsync(role);

        if (!result.Succeeded)
            return new CreateRoleCommandResponse
            {
                Success = false,
                Message = string.Join(", ", result.Errors.Select(e => e.Description))
            };

        return new CreateRoleCommandResponse
        {
            Success = true,
            Message = "Rol uğurla yaradıldı."
        };
    }
}