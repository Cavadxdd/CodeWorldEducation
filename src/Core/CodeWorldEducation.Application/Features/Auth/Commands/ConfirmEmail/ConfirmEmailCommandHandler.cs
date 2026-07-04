using CodeWorldEducation.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace CodeWorldEducation.Application.Features.Auth.Commands.ConfirmEmail;

public class ConfirmEmailCommandHandler : IRequestHandler<ConfirmEmailCommandRequest, ConfirmEmailCommandResponse>
{
    private readonly UserManager<AppUser> _userManager;

    public ConfirmEmailCommandHandler(UserManager<AppUser> userManager)
    {
        _userManager = userManager;
    }

    public async Task<ConfirmEmailCommandResponse> Handle(
        ConfirmEmailCommandRequest request,
        CancellationToken cancellationToken)
    {
        var user = await _userManager.FindByEmailAsync(request.Email);
        if (user == null)
            return new ConfirmEmailCommandResponse
            {
                Success = false,
                Message = "İstifadəçi tapılmadı."
            };

        var result = await _userManager.ConfirmEmailAsync(user, request.Token);

        if (!result.Succeeded)
            return new ConfirmEmailCommandResponse
            {
                Success = false,
                Message = string.Join(", ", result.Errors.Select(e => e.Description))
            };

        return new ConfirmEmailCommandResponse
        {
            Success = true,
            Message = "Email uğurla təsdiqləndi."
        };
    }
}