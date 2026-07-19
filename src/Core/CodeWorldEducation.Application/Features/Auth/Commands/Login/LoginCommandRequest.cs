using MediatR;

namespace CodeWorldEducation.Application.Features.Auth.Commands.Login;

public class LoginCommandRequest : IRequest<LoginCommandResponse>
{
    public string Email { get; set; } = null!;
    public string Password { get; set; } = null!;
}