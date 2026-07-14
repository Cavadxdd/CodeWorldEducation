using CodeWorldEducation.Application.Common.Courses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeWorldEducation.Application.Features.Applications.Queries.GetCoursesByCategory
{
    public class GetCoursesByCategoryQueryResponse
    {
        public List<GetCourseListDto> Courses { get; set; }
    }
}
