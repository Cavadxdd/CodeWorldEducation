using CodeWorldEducation.Application.Common.Course;
using CodeWorldEducation.Application.Common.Courses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeWorldEducation.Application.Abstraction.Services
{
    public interface ICourseService
    {
        Task<List<GetCourseListDto>> GetAllAsync();
        Task<GetCourseDetailDto> GetByIdAsync(int id);
        Task<GetCourseListDto> CreateAsync(CreateCourseDto dto);
        Task<GetCourseListDto> UpdateAsync(UpdateCourseDto dto);
        Task DeleteAsync(int id);
    }
}
