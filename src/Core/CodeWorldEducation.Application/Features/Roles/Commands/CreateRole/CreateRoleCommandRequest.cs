using MediatR;

namespace CodeWorldEducation.Application.Features.Roles.Commands.CreateRole;

public class CreateRoleCommandRequest : IRequest<CreateRoleCommandResponse>
{
    public string Name { get; set; } = null!;
}