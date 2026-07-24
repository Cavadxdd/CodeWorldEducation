using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using CodeWorldEducation.Application.Abstraction.Services;
using CodeWorldEducation.Domain.Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace CodeWorldEducation.Infrastructure.Services;

public class TokenService : ITokenService
{
    private readonly IConfiguration _configuration;

    public TokenService(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public string GenerateToken(AppUser user, IList<string> roles)
    {
        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new Claim(ClaimTypes.Email, user.Email!),
            new Claim(ClaimTypes.GivenName, user.FirstName),
            new Claim(ClaimTypes.Surname, user.LastName),
        };

        foreach (var role in roles)
            claims.Add(new Claim(ClaimTypes.Role, role));

        Console.WriteLine($"Config Secret: {_configuration["Jwt:Secret"]}");
        Console.WriteLine($"Env Secret: {Environment.GetEnvironmentVariable("JWT_SECRET")}");

        var secret = Environment.GetEnvironmentVariable(_configuration["Jwt:Secret"]!)
        ?? throw new InvalidOperationException("JWT secret not found.");

        var issuer = Environment.GetEnvironmentVariable(_configuration["Jwt:Issuer"]!)
            ?? throw new InvalidOperationException("JWT issuer not found.");

        var audience = Environment.GetEnvironmentVariable(_configuration["Jwt:Audience"]!)
            ?? throw new InvalidOperationException("JWT audience not found.");

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secret));

        var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            issuer: issuer,
        audience: audience,
        claims: claims,
        expires: DateTime.UtcNow.AddDays(1),
        signingCredentials: credentials);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}