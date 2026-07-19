using MediatR;

namespace CodeWorldEducation.Application.Features.Roles.Commands.UpdateRole;

public class UpdateRoleCommandRequest : IRequest<UpdateRoleCommandResponse>
{
    public string Id { get; set; } = null!;
    public string NewName { get; set; } = null!;
}