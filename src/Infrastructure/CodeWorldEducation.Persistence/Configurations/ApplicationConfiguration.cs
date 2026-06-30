using CodeWorldEducation.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeWorldEducation.Persistence.Configurations
{
    public class ApplicationConfiguration : IEntityTypeConfiguration<Domain.Entities.Application>
    {
        public void Configure(EntityTypeBuilder<Domain.Entities.Application> builder)
        {
            builder.ToTable("Applications");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.CreatedAt).IsRequired();
            builder.Property(e => e.UpdatedAt).IsRequired();
            builder.Property(e => e.IsDeleted).IsRequired().HasDefaultValue(false);
            builder.HasQueryFilter(e => !e.IsDeleted);

            builder.Property(a => a.FirstName)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(a => a.LastName)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(a => a.Phone)
                .IsRequired()
                .HasMaxLength(20);

            builder.Property(a => a.ApplicantType)
                .IsRequired();

            builder.Property(a => a.Field)
                .HasMaxLength(100);

            builder.Property(a => a.TeachingMode);

            builder.Property(a => a.GitHubUrl)
                .HasMaxLength(255);

            builder.Property(a => a.BehanceUrl)
                .HasMaxLength(255);

            builder.Property(a => a.CvFilePath)
                .HasMaxLength(500);

            builder.Property(a => a.CvOriginalFileName)
                .HasMaxLength(255);

            builder.Property(a => a.Status)
                .IsRequired()
                .HasDefaultValue(ApplicationStatus.New);

            builder.Property(a => a.WhatsAppMessage)
                .HasMaxLength(500);

            builder.Property(a => a.WhatsAppRedirectUrl)
                .HasMaxLength(500);

            builder.Property(a => a.SubmittedAt)
                .IsRequired()
                .HasDefaultValue(DateTime.UtcNow);

            builder.Property(a => a.IpAddress)
                .HasMaxLength(45);

            builder.HasOne(a => a.Course)
                .WithMany(c => c.Applications)
                .HasForeignKey(a => a.CourseId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
