using MediatR;

namespace CodeWorldEducation.Application.Features.Auth.Commands.ResetPassword;

public class ResetPasswordCommandRequest : IRequest<ResetPasswordCommandResponse>
{
    public string Email { get; set; } = null!;
    public string Token { get; set; } = null!;
    public string NewPassword { get; set; } = null!;
    public string ConfirmNewPassword { get; set; } = null!;
}