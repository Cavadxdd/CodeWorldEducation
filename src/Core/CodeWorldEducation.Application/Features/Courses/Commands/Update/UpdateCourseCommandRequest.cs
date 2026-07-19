using CodeWorldEducation.Application.Common.Course;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeWorldEducation.Application.Features.Courses.Commands.Update
{
    public class UpdateCourseCommandRequest : IRequest<UpdateCourseCommandResponse>
    {
        public int Id { get; set; }
        public UpdateCourseDto Dto { get; set; }

        public UpdateCourseCommandRequest(int id, UpdateCourseDto dto)
        {
            Id = id;
            Dto = dto;
        }
    }
}
