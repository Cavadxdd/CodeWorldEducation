using CodeWorldEducation.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace CodeWorldEducation.Application.Features.Auth.Commands.ResetPassword;

public class ResetPasswordCommandHandler : IRequestHandler<ResetPasswordCommandRequest, ResetPasswordCommandResponse>
{
    private readonly UserManager<AppUser> _userManager;

    public ResetPasswordCommandHandler(UserManager<AppUser> userManager)
    {
        _userManager = userManager;
    }

    public async Task<ResetPasswordCommandResponse> Handle(
        ResetPasswordCommandRequest request,
        CancellationToken cancellationToken)
    {
        if (request.NewPassword != request.ConfirmNewPassword)
            return new ResetPasswordCommandResponse
            {
                Success = false,
                Message = "Parollar uyğun deyil."
            };

        var user = await _userManager.FindByEmailAsync(request.Email);
        if (user == null)
            return new ResetPasswordCommandResponse
            {
                Success = false,
                Message = "İstifadəçi tapılmadı."
            };

        var result = await _userManager.ResetPasswordAsync(user, request.Token, request.NewPassword);

        if (!result.Succeeded)
            return new ResetPasswordCommandResponse
            {
                Success = false,
                Message = string.Join(", ", result.Errors.Select(e => e.Description))
            };

        return new ResetPasswordCommandResponse
        {
            Success = true,
            Message = "Parol uğurla yeniləndi."
        };
    }
}