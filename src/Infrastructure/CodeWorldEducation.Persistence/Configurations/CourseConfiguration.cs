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
    public class CourseConfiguration : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            builder.ToTable("Courses");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.CreatedAt).IsRequired();
            builder.Property(e => e.UpdatedAt).IsRequired();
            builder.Property(e => e.IsDeleted).IsRequired().HasDefaultValue(false);
            builder.HasQueryFilter(e => !e.IsDeleted);

            builder.Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(150);

            builder.Property(c => c.Slug)
                .IsRequired()
                .HasMaxLength(100);

            builder.HasIndex(c => c.Slug)
                .IsUnique();

            builder.Property(c => c.Description)
                .IsRequired();

            builder.Property(c => c.Duration)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(c => c.Intensity)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(c => c.TeachingMode)
                .IsRequired();

            builder.Property(c => c.ThumbnailUrl)
                .HasMaxLength(255);

            builder.Property(c => c.IsActive)
                .IsRequired()
                .HasDefaultValue(true);

            builder.Property(c => c.SortOrder)
                .IsRequired()
                .HasDefaultValue(0);

            builder.HasOne(c => c.Category)
                .WithMany(cat => cat.Courses)
                .HasForeignKey(c => c.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
