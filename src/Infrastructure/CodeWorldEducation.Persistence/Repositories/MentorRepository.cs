using CodeWorldEducation.Application.Repositories;
using CodeWorldEducation.Domain.Entities;
using CodeWorldEducation.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeWorldEducation.Persistence.Repositories
{
    public class MentorRepository : GenericRepository<Mentor>, IMentorRepository
    {
        public MentorRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<List<Mentor>> GetActiveAsync()
        {
            return await _context.Mentors
                .Where(m => m.IsActive && !m.IsDeleted)
                .OrderBy(m => m.SortOrder)
                .ToListAsync();
        }

        public async Task<Mentor?> GetWithCoursesAsync(int id)
        {
            return await _context.Mentors
                .Include(m => m.MentorCourses)
                    .ThenInclude(mc => mc.Course)
                .FirstOrDefaultAsync(m => m.Id == id && !m.IsDeleted);
        }

        public async Task<List<Mentor>> GetByCourseAsync(int courseId)
        {
            return await _context.Mentors
                .Include(m => m.MentorCourses)
                .Where(m => m.MentorCourses.Any(mc => mc.CourseId == courseId)
                    && m.IsActive
                    && !m.IsDeleted)
                .OrderBy(m => m.SortOrder)
                .ToListAsync();
        }
    }
}
