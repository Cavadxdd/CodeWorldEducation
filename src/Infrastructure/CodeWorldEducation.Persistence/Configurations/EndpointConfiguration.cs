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
    public class EndpointConfiguration : IEntityTypeConfiguration<Endpoint>
    {
        public void Configure(EntityTypeBuilder<Endpoint> builder)
        {
            builder.Property(x => x.Code)
                .IsRequired()
                .HasMaxLength(300);

            builder.HasIndex(x => x.Code)
                .IsUnique();

            builder.Property(x => x.HttpMethod)
                .IsRequired()
                .HasMaxLength(10);

            builder.Property(x => x.Route)
                .IsRequired()
                .HasMaxLength(300);

            builder.Property(x => x.Definition)
                .HasMaxLength(500);

            builder.Property(x => x.Menu)
                .HasMaxLength(100);

            builder.HasMany(x => x.EndpointRoles)
                .WithOne(x => x.Endpoint)
                .HasForeignKey(x => x.EndpointId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}

