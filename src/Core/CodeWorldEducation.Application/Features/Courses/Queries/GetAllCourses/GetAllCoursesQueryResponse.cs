using CodeWorldEducation.Application.Common.Courses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeWorldEducation.Application.Features.Courses.Queries.GetAllCourses
{
    public class GetAllCoursesQueryResponse
    {
        public List<GetCourseListDto> Courses { get; set; }
    }
}
