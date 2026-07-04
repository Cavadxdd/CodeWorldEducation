namespace CodeWorldEducation.Application.Features.Auth.Commands.ConfirmEmail;

public class ConfirmEmailCommandResponse
{
    public bool Success { get; set; }
    public string Message { get; set; } = null!;
}