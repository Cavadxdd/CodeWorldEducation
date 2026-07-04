using CodeWorldEducation.Application.Common.Course;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeWorldEducation.Application.Features.Courses.Commands.Create
{
    public class CreateCourseCommandRequest : IRequest<CreateCourseCommandResponse>
    {
        public CreateCourseDto Dto { get; set; }
    }
}
