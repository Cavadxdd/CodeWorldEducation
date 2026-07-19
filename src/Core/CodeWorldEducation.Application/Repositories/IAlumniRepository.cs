using CodeWorldEducation.Domain.Entities;
using CodeWorldEducation.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeWorldEducation.Application.Repositories
{
    public interface IAlumniRepository : IGenericRepository<Alumni>
    {
        Task<List<Alumni>> GetActiveAsync();
        Task<List<Alumni>> GetByTypeAsync(AlumniType type);
        Task<Alumni?> GetDetailAsync(int id);
    }
}
