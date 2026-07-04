namespace CodeWorldEducation.Application.Features.Auth.Commands.ResetPassword;

public class ResetPasswordCommandResponse
{
    public bool Success { get; set; }
    public string Message { get; set; } = null!;
}