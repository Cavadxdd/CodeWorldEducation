using Microsoft.AspNetCore.Identity;

namespace CodeWorldEducation.Domain.Entities;

public class AppRole : IdentityRole<Guid>
{
    public AppRole() { }
    public AppRole(string roleName) : base(roleName) { }
}