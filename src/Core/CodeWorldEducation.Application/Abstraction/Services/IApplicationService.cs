using CodeWorldEducation.Application.Common.Application;
using CodeWorldEducation.Application.Common.Applications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeWorldEducation.Application.Abstraction.Services
{
    public interface IApplicationService
    {
        Task<List<GetApplicationDto>> GetAllAsync();
        Task<GetApplicationDto> GetByIdAsync(int id);
        Task<GetApplicationDto> CreateAsync(CreateApplicationDto dto);
        Task<GetApplicationDto> UpdateAsync(UpdateApplicationDto dto);
        Task DeleteAsync(int id);
    }
}
