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
    public class SyllabusItemConfiguration : IEntityTypeConfiguration<SyllabusItem>
    {
        public void Configure(EntityTypeBuilder<SyllabusItem> builder)
        {
            builder.ToTable("SyllabusItems");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.CreatedAt).IsRequired();
            builder.Property(e => e.UpdatedAt).IsRequired();
            builder.Property(e => e.IsDeleted).IsRequired().HasDefaultValue(false);
            builder.HasQueryFilter(e => !e.IsDeleted);

            builder.Property(s => s.Title)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(s => s.Content)
                .IsRequired();

            builder.Property(s => s.OrderIndex)
                .IsRequired();

            builder.Property(s => s.WeekNumber);

            builder.HasOne(s => s.Course)
                .WithMany(c => c.SyllabusItems)
                .HasForeignKey(s => s.CourseId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
