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
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("Categories");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.CreatedAt).IsRequired();
            builder.Property(e => e.UpdatedAt).IsRequired();
            builder.Property(e => e.IsDeleted).IsRequired().HasDefaultValue(false);
            builder.HasQueryFilter(e => !e.IsDeleted);

            builder.Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(c => c.Slug)
                .IsRequired()
                .HasMaxLength(50);

            builder.HasIndex(c => c.Slug)
                .IsUnique();

            builder.Property(c => c.IsActive)
                .IsRequired()
                .HasDefaultValue(true);

            
        }
    }
}
