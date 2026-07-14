using CodeWorldEducation.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CodeWorldEducation.Persistence.Contexts
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<SyllabusItem> SyllabusItems { get; set; }
        public DbSet<Mentor> Mentors { get; set; }
        public DbSet<MentorTechnology> MentorTechnologies { get; set; }
        public DbSet<MentorCourse> MentorCourses { get; set; }
        public DbSet<Alumni> Alumni { get; set; }
        public DbSet<Domain.Entities.Application> Applications { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
