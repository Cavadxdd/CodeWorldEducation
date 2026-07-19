using CodeWorldEducation.Application.Common.Courses;
using CodeWorldEducation.Application.Common.Mentor;
using CodeWorldEducation.Application.Common.Mentors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeWorldEducation.Application.Abstraction.Services
{
    public interface IMentorService
    {
        Task<List<GetMentorDto>> GetAllAsync();
        Task<GetMentorDto> GetByIdAsync(int id);
        Task<List<GetCourseListDto>> GetMentorCoursesAsync(int mentorId);
        Task<GetMentorDetailDto> GetDetailAsync(int id);
        Task<GetMentorDto> CreateAsync(CreateMentorDto dto);
        Task<GetMentorDto> UpdateAsync(int id, UpdateMentorDto dto);
        Task DeleteAsync(int id);
    }
}
