using CodeWorldEducation.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeWorldEducation.Application.Repositories
{
    public interface ICourseRepository : IGenericRepository<Course>
    {
        Task<Course?> GetBySlugAsync(string slug);
        Task<List<Course>> GetByCategoryAsync(int categoryId);
        Task<List<Course>> GetWithSyllabusAsync();
        Task<Course?> GetDetailWithMentorsAsync(int id);

        Task<List<Course>> GetAllWithCategoryAsync();
        Task<Course?> GetWithCategoryByIdAsync(int id);
    }
}
