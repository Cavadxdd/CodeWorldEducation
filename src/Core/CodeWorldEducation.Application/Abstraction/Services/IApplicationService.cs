using CodeWorldEducation.Application.Common.Applications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CodeWorldEducation.Domain.Enums;

namespace CodeWorldEducation.Application.Abstraction.Services
{
    public interface IApplicationService
    {
        Task<List<GetApplicationDto>> GetAllAsync(ApplicantType? type = null, ApplicationStatus? status = null);
        Task<GetApplicationDto> GetByIdAsync(int id);
        Task<GetApplicationDto> CreateAsync(CreateApplicationDto dto);
        Task<GetApplicationDto> ApproveAsync(int id, string reviewedBy);
        Task<GetApplicationDto> RejectAsync(int id, string reviewedBy);
        Task DeleteAsync(int id);
    }
}
