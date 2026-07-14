using CodeWorldEducation.Application.Common.Alumni;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeWorldEducation.Application.Abstraction.Services
{
    public interface IAlumniService
    {
        Task<List<GetAlumniDetailDto>> GetAllAsync();
        Task<GetAlumniDetailDto> GetByIdAsync(int id);
        Task<List<GetAlumniDetailDto>> GetFeaturedAsync();
        Task<GetAlumniDetailDto> GetDetailAsync(int id);
        Task<GetAlumniDetailDto> CreateAsync(CreateAlumniDto dto);
        Task<GetAlumniDetailDto> UpdateAsync(int id,UpdateAlumniDto dto);
        Task DeleteAsync(int id);
    }
}
