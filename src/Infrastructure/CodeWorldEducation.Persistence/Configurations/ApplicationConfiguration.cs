using CodeWorldEducation.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CodeWorldEducation.Persistence.Configurations
{
    public class ApplicationConfiguration : IEntityTypeConfiguration<Domain.Entities.Application>
    {
        public void Configure(EntityTypeBuilder<Domain.Entities.Application> builder)
        {
            builder.HasKey(a => a.Id);

            builder.Property(a => a.FullName)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(a => a.PhoneNumber)
                .IsRequired()
                .HasMaxLength(20);

            builder.Property(a => a.ApplicantType)
                .IsRequired();

            builder.Property(a => a.EducationMode)
                .IsRequired(false);

            builder.Property(a => a.BehanceUrl)
                .HasMaxLength(300);

            builder.Property(a => a.DribbbleUrl)
                .HasMaxLength(300);

            builder.Property(a => a.CvFilePath)
                .HasMaxLength(500);

            builder.Property(a => a.CvOriginalFileName)
                .HasMaxLength(255);

            builder.Property(a => a.Note)
                .HasMaxLength(1000);

            builder.Property(a => a.Status)
                .IsRequired();

            builder.Property(a => a.ReviewedBy)
                .HasMaxLength(100);

            builder.Property(a => a.WhatsAppMessage)
                .HasMaxLength(1000);

            builder.Property(a => a.WhatsAppRedirectUrl)
                .HasMaxLength(1000);

            builder.HasOne(a => a.Course)
                .WithMany(c => c.Applications)
                .HasForeignKey(a => a.CourseId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}