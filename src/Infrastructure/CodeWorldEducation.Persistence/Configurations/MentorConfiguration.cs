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
    public class MentorConfiguration : IEntityTypeConfiguration<Mentor>
    {
        public void Configure(EntityTypeBuilder<Mentor> builder)
        {
            builder.ToTable("Mentors");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.CreatedAt).IsRequired();
            builder.Property(e => e.UpdatedAt).IsRequired();
            builder.Property(e => e.IsDeleted).IsRequired().HasDefaultValue(false);
            builder.HasQueryFilter(e => !e.IsDeleted);

            builder.Property(m => m.FullName)
                .IsRequired()
                .HasMaxLength(150);

            builder.Property(m => m.Position)
                .IsRequired()
                .HasMaxLength(150);

            builder.Property(m => m.PhotoUrl)
                .IsRequired()
                .HasMaxLength(255);

            builder.Property(m => m.LinkedInUrl)
                .HasMaxLength(255);

            builder.Property(m => m.Technologies)
                .IsRequired();

            builder.Property(m => m.Bio)
                .HasMaxLength(500);

            builder.Property(m => m.IsActive)
                .IsRequired()
                .HasDefaultValue(true);

            builder.Property(m => m.SortOrder)
                .IsRequired()
                .HasDefaultValue(0);
        }
    }
}
