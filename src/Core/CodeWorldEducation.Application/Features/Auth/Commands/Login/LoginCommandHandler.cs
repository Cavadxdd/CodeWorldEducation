using CodeWorldEducation.Application.Abstraction.Services;
using CodeWorldEducation.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace CodeWorldEducation.Application.Features.Auth.Commands.Login;

public class LoginCommandHandler : IRequestHandler<LoginCommandRequest, LoginCommandResponse>
{
    private readonly UserManager<AppUser> _userManager;
    private readonly ITokenService _tokenService;

    public LoginCommandHandler(UserManager<AppUser> userManager, ITokenService tokenService)
    {
        _userManager = userManager;
        _tokenService = tokenService;
    }

    public async Task<LoginCommandResponse> Handle(
        LoginCommandRequest request,
        CancellationToken cancellationToken)
    {
        var user = await _userManager.FindByEmailAsync(request.Email);
        if (user == null)
            return new LoginCommandResponse { Success = false, Message = "Email və ya parol yanlışdır." };

        if (!user.IsActive)
            return new LoginCommandResponse { Success = false, Message = "Hesabınız deaktivdir." };

        if (!await _userManager.IsEmailConfirmedAsync(user))
            return new LoginCommandResponse { Success = false, Message = "Email təsdiqlənməyib." };

        var isPasswordValid = await _userManager.CheckPasswordAsync(user, request.Password);
        if (!isPasswordValid)
            return new LoginCommandResponse { Success = false, Message = "Email və ya parol yanlışdır." };

        var roles = await _userManager.GetRolesAsync(user);
        var token = _tokenService.GenerateToken(user, roles);

        return new LoginCommandResponse
        {
            Success = true,
            Message = "Giriş uğurlu oldu.",
            Token = token
        };
    }
}