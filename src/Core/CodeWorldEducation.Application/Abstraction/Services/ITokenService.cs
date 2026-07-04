using CodeWorldEducation.Domain.Entities;

namespace CodeWorldEducation.Application.Abstraction.Services;

public interface ITokenService
{
    string GenerateToken(AppUser user, IList<string> roles);
}