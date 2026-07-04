using CodeWorldEducation.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace CodeWorldEducation.Application.Features.Auth.Commands.ForgotPassword;

public class ForgotPasswordCommandHandler : IRequestHandler<ForgotPasswordCommandRequest, ForgotPasswordCommandResponse>
{
    private readonly UserManager<AppUser> _userManager;

    public ForgotPasswordCommandHandler(UserManager<AppUser> userManager)
    {
        _userManager = userManager;
    }

    public async Task<ForgotPasswordCommandResponse> Handle(
        ForgotPasswordCommandRequest request,
        CancellationToken cancellationToken)
    {
        var user = await _userManager.FindByEmailAsync(request.Email);
        if (user == null)
            return new ForgotPasswordCommandResponse
            {
                Success = false,
                Message = "Bu email ilə qeydiyyatlı istifadəçi tapılmadı."
            };

        var token = await _userManager.GeneratePasswordResetTokenAsync(user);

        // TODO: Email göndərmə burada olacaq (Google SMTP)

        return new ForgotPasswordCommandResponse
        {
            Success = true,
            Message = "Parol sıfırlama linki emailinizə göndərildi."
        };
    }
}