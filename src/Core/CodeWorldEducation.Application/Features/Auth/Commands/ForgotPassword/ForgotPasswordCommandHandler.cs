using CodeWorldEducation.Application.Abstraction.Services;
using CodeWorldEducation.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace CodeWorldEducation.Application.Features.Auth.Commands.ForgotPassword;

public class ForgotPasswordCommandHandler : IRequestHandler<ForgotPasswordCommandRequest, ForgotPasswordCommandResponse>
{
    private readonly UserManager<AppUser> _userManager;
    private readonly IEmailService _emailService;

    public ForgotPasswordCommandHandler(UserManager<AppUser> userManager, IEmailService emailService)
    {
        _userManager = userManager;
        _emailService = emailService;
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

         var resetLink = $"https://localhost:7001/api/auth/reset-password?email={user.Email}&token={Uri.EscapeDataString(token)}";

        await _emailService.SendEmailAsync(
            user.Email!,
            "Parol Sıfırlama",
            $"<h3>Salam!</h3><p>Parolunuzu sıfırlamaq üçün <a href='{resetLink}'>bura klikləyin</a>.</p>"
        );

        return new ForgotPasswordCommandResponse
        {
            Success = true,
            Message = "Parol sıfırlama linki emailinizə göndərildi."
        };
    }
}