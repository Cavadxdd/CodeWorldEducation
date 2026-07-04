using MediatR;

namespace CodeWorldEducation.Application.Features.Auth.Commands.ForgotPassword;

public class ForgotPasswordCommandRequest : IRequest<ForgotPasswordCommandResponse>
{
    public string Email { get; set; } = null!;
}