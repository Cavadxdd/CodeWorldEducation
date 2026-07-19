using CodeWorldEducation.Application.Abstraction.Services;
using CodeWorldEducation.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;

namespace CodeWorldEducation.Application.Features.Auth.Commands.Register;

public class RegisterCommandHandler : IRequestHandler<RegisterCommandRequest, RegisterCommandResponse>
{
    private readonly UserManager<AppUser> _userManager;
    private readonly IEmailService _emailService;
    private readonly IConfiguration _configuration;

    public RegisterCommandHandler(UserManager<AppUser> userManager, IEmailService emailService, IConfiguration configuration)
    {
        _userManager = userManager;
        _emailService = emailService;
        _configuration = configuration;
    }

    public async Task<RegisterCommandResponse> Handle(
        RegisterCommandRequest request,
        CancellationToken cancellationToken)
    {
        if (request.Password != request.ConfirmPassword)
            return new RegisterCommandResponse { Success = false, Message = "Parollar uyğun deyil." };

        var existingUser = await _userManager.FindByEmailAsync(request.Email);
        if (existingUser != null)
            return new RegisterCommandResponse { Success = false, Message = "Bu email artıq qeydiyyatdadır." };

        var user = new AppUser
        {
            FirstName = request.FirstName,
            LastName = request.LastName,
            Email = request.Email,
            UserName = request.Email
        };

        var result = await _userManager.CreateAsync(user, request.Password);

        if (!result.Succeeded)
            return new RegisterCommandResponse
            {
                Success = false,
                Message = string.Join(", ", result.Errors.Select(e => e.Description))
            };

        var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);

        var baseUrl = _configuration["App:BaseUrl"];

        var confirmLink =
            $"{baseUrl}/api/auth/confirm-email?email={user.Email}&token={Uri.EscapeDataString(token)}";

        await _emailService.SendEmailAsync(
            user.Email!,
            "Email Təsdiqləmə",
            $"<h3>Salam {user.FirstName}!</h3><p>Email ünvanınızı təsdiqləmək üçün <a href='{confirmLink}'>bura klikləyin</a>.</p>"
        );

        return new RegisterCommandResponse
        {
            Success = true,
            Message = "Qeydiyyat uğurlu oldu. Email təsdiqləmə linki göndərildi."
        };
    }
}