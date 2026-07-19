namespace CodeWorldEducation.Application.Features.Auth.Commands.ForgotPassword;

public class ForgotPasswordCommandResponse
{
    public bool Success { get; set; }
    public string Message { get; set; } = null!;
}