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
    public class AlumniConfiguration : IEntityTypeConfiguration<Alumni>
    {
        public void Configure(EntityTypeBuilder<Alumni> builder)
        {
            builder.ToTable("Alumni");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.CreatedAt).IsRequired();
            builder.Property(e => e.UpdatedAt).IsRequired();
            builder.Property(e => e.IsDeleted).IsRequired().HasDefaultValue(false);
            builder.HasQueryFilter(e => !e.IsDeleted);

            builder.Property(a => a.FullName)
                .IsRequired()
                .HasMaxLength(150);

            builder.Property(a => a.PhotoUrl)
                .HasMaxLength(255);

            builder.Property(a => a.AlumniType)
                .IsRequired();

            builder.Property(a => a.CompletedCourse)
                .IsRequired()
                .HasMaxLength(150);

            builder.Property(a => a.CurrentCompany)
                .HasMaxLength(150);

            builder.Property(a => a.CurrentPosition)
                .HasMaxLength(150);

            builder.Property(a => a.GitHubUrl)
                .HasMaxLength(255);

            builder.Property(a => a.BehanceUrl)
                .HasMaxLength(255);

            builder.Property(a => a.ProjectUrl)
                .HasMaxLength(255);

            builder.Property(a => a.Testimonial)
                .HasMaxLength(500);

            builder.Property(a => a.IsActive)
                .IsRequired()
                .HasDefaultValue(true);
        }
    }
}
