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
            builder.HasQueryFilter(e => !e.IsDeleted);

            builder.Property(a => a.FirstName)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(a => a.LastName)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(a => a.PhotoUrl)
                .IsRequired()
                .HasMaxLength(500);

            builder.Property(a => a.CurrentCompany)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(a => a.PortfolioUrl)
                .HasMaxLength(500);

            builder.Property(a => a.TestimonialText)
                .HasMaxLength(1000);

            builder.HasOne(a => a.Course)
                .WithMany(c => c.Alumni)
                .HasForeignKey(a => a.CourseId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
