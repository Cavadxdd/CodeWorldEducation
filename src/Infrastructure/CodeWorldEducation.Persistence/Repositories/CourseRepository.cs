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
    public class CourseRepository : GenericRepository<Course>, ICourseRepository
    {
        public CourseRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<Course?> GetBySlugAsync(string slug)
        {
            return await _context.Courses
                .Include(c => c.Category)
                .Include(c => c.SyllabusItems.OrderBy(s => s.OrderIndex))
                .FirstOrDefaultAsync(c => c.Slug == slug && !c.IsDeleted);
        }

        public async Task<List<Course>> GetByCategoryAsync(int categoryId)
        {
            return await _context.Courses
                .Include(c => c.Category)
                .Where(c => c.CategoryId == categoryId && !c.IsDeleted)
                .OrderBy(c => c.SortOrder)
                .ToListAsync();
        }

        public async Task<List<Course>> GetWithSyllabusAsync()
        {
            return await _context.Courses
                .Include(c => c.Category)
                .Include(c => c.SyllabusItems.OrderBy(s => s.OrderIndex))
                .Where(c => !c.IsDeleted)
                .OrderBy(c => c.SortOrder)
                .ToListAsync();
        }

        public async Task<Course?> GetDetailWithMentorsAsync(int id)
        {
            return await _context.Courses
                .Include(c => c.Category)
                .Include(c => c.SyllabusItems.OrderBy(s => s.OrderIndex))
                .Include(c => c.MentorCourses)
                    .ThenInclude(mc => mc.Mentor)
                .FirstOrDefaultAsync(c => c.Id == id && !c.IsDeleted);
        }
    }
}
