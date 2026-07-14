using CodeWorldEducation.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeWorldEducation.Application.Repositories
{
    public interface IMentorRepository : IGenericRepository<Mentor>
    {
        Task<List<Mentor>> GetActiveAsync();
        Task<Mentor?> GetWithCoursesAsync(int id);
        Task<List<Mentor>> GetByCourseAsync(int courseId);
    }
}
