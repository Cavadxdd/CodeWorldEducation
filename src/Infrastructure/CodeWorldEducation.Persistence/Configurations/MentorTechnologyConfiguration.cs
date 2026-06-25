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
    public class MentorTechnologyConfiguration : IEntityTypeConfiguration<MentorTechnology>
    {
        public void Configure(EntityTypeBuilder<MentorTechnology> builder)
        {
            builder.ToTable("MentorTechnologies");

            builder.HasKey(e => e.Id);

            builder.HasQueryFilter(e => !e.IsDeleted);

            builder.Property(mt => mt.TechnologyName)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(mt => mt.LogoUrl)
                .IsRequired()
                .HasMaxLength(500);

            builder.HasOne(mt => mt.Mentor)
                .WithMany(m => m.Technologies)
                .HasForeignKey(mt => mt.MentorId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
