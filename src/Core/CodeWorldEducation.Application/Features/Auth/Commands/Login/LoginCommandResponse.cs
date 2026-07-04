namespace CodeWorldEducation.Application.Features.Auth.Commands.Login;

public class LoginCommandResponse
{
    public bool Success { get; set; }
    public string Message { get; set; } = null!;
    public string? Token { get; set; }
}