using CodeWorldEducation.Application.Repositories;
using CodeWorldEducation.Domain.Entities;
using CodeWorldEducation.Domain.Enums;
using CodeWorldEducation.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeWorldEducation.Persistence.Repositories
{
    public class AlumniRepository : GenericRepository<Alumni>, IAlumniRepository
    {
        public AlumniRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<List<Alumni>> GetActiveAsync()
        {
            return await _context.Alumni
                .Where(a => a.IsActive && !a.IsDeleted)
                .OrderByDescending(a => a.GraduatedAt)
                .ToListAsync();
        }

        public async Task<List<Alumni>> GetByTypeAsync(AlumniType type)
        {
            return await _context.Alumni
                .Where(a => a.AlumniType == type && a.IsActive && !a.IsDeleted)
                .OrderByDescending(a => a.GraduatedAt)
                .ToListAsync();
        }

        public async Task<Alumni?> GetDetailAsync(int id)
        {
            return await _context.Alumni
                .FirstOrDefaultAsync(a => a.Id == id && !a.IsDeleted);
        }
    }
}
