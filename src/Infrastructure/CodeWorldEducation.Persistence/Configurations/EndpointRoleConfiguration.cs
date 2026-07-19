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
    public class EndpointRoleConfiguration : IEntityTypeConfiguration<EndpointRole>
    {
        public void Configure(EntityTypeBuilder<EndpointRole> builder)
        {
            builder.Property(x => x.RoleName)
                .IsRequired()
                .HasMaxLength(100);

            builder.HasOne(x => x.Endpoint)
                .WithMany(x => x.EndpointRoles)
                .HasForeignKey(x => x.EndpointId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
