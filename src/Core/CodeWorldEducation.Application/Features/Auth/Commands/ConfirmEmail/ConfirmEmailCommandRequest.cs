using MediatR;

namespace CodeWorldEducation.Application.Features.Auth.Commands.ConfirmEmail;

public class ConfirmEmailCommandRequest : IRequest<ConfirmEmailCommandResponse>
{
    public string Email { get; set; } = null!;
    public string Token { get; set; } = null!;
}