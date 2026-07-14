using CodeWorldEducation.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeWorldEducation.Persistence.Configurations
{
    public class MentorCourseConfiguration : IEntityTypeConfiguration<MentorCourse>
    {
        public void Configure(EntityTypeBuilder<MentorCourse> builder)
        {
            builder.ToTable("MentorCourses");
            builder.HasKey(mc => new { mc.MentorId, mc.CourseId });

            builder.HasOne(mc => mc.Mentor)
                .WithMany(m => m.MentorCourses)
                .HasForeignKey(mc => mc.MentorId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(mc => mc.Course)
                .WithMany(c => c.MentorCourses)
                .HasForeignKey(mc => mc.CourseId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
