using CodeWorldEducation.Application.Repositories;
using CodeWorldEducation.Domain.Entities;
using CodeWorldEducation.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeWorldEducation.Persistence.Repositories
{
    public class EndpointRepository : GenericRepository<Endpoint>, IEndpointRepository
    {
        public EndpointRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<List<Endpoint>> GetAllWithRolesAsync()
        {
            return await _context.Endpoints
                .Include(x => x.EndpointRoles)
                .AsNoTracking()
                .ToListAsync();
        }
    }
}
