using MediatR;

namespace CodeWorldEducation.Application.Features.Roles.Commands.DeleteRole;

public class DeleteRoleCommandRequest : IRequest<DeleteRoleCommandResponse>
{
    public string Id { get; set; } = null!;
}