using CodeWorldEducation.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace CodeWorldEducation.Persistence.Contexts;

public class AppDbContext : IdentityDbContext<AppUser, AppRole, Guid>
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Course> Courses { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<SyllabusItem> SyllabusItems { get; set; }
    public DbSet<Mentor> Mentors { get; set; }
    public DbSet<MentorCourse> MentorCourses { get; set; }
    public DbSet<Alumni> Alumni { get; set; }
    public DbSet<Domain.Entities.Application> Applications { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}