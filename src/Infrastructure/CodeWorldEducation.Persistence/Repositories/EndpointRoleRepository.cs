using CodeWorldEducation.Application.Repositories;
using CodeWorldEducation.Domain.Entities;
using CodeWorldEducation.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeWorldEducation.Persistence.Repositories
{
    public class EndpointRoleRepository
        : GenericRepository<EndpointRole>, IEndpointRoleRepository
    {
        public EndpointRoleRepository(AppDbContext context)
            : base(context)
        {
        }
    }
}
