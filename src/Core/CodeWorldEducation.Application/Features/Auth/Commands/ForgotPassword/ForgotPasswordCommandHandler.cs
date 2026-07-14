using CodeWorldEducation.Application.Abstraction.Services;
using CodeWorldEducation.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;

namespace CodeWorldEducation.Application.Features.Auth.Commands.ForgotPassword;

public class ForgotPasswordCommandHandler : IRequestHandler<ForgotPasswordCommandRequest, ForgotPasswordCommandResponse>
{
    private readonly UserManager<AppUser> _userManager;
    private readonly IEmailService _emailService;
    private readonly IConfiguration _configuration;

    public ForgotPasswordCommandHandler(UserManager<AppUser> userManager, IEmailService emailService, IConfiguration configuration)
    {
        _userManager = userManager;
        _emailService = emailService;
        _configuration = configuration;
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

        var baseUrl = _configuration["App:BaseUrl"];

        var resetLink =
            $"{baseUrl}/api/auth/reset-password?email={user.Email}&token={Uri.EscapeDataString(token)}";

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