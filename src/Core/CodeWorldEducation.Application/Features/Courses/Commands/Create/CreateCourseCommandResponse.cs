using CodeWorldEducation.Application.Common.Courses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeWorldEducation.Application.Features.Courses.Commands.Create
{
    public class CreateCourseCommandResponse
    {
        public GetCourseListDto Course { get; set; }
    }
}
