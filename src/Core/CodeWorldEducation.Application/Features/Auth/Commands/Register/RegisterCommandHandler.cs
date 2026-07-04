using CodeWorldEducation.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace CodeWorldEducation.Application.Features.Auth.Commands.Register;

public class RegisterCommandHandler : IRequestHandler<RegisterCommandRequest, RegisterCommandResponse>
{
    private readonly UserManager<AppUser> _userManager;

    public RegisterCommandHandler(UserManager<AppUser> userManager)
    {
        _userManager = userManager;
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

        // TODO: Email göndərmə burada olacaq (Google SMTP)

        return new RegisterCommandResponse
        {
            Success = true,
            Message = "Qeydiyyat uğurlu oldu. Email təsdiqləmə linki göndərildi."
        };
    }
}