using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeWorldEducation.Application.Features.Courses.Commands.Delete
{
    public class DeleteCourseCommandRequest : IRequest<DeleteCourseCommandResponse>
    {
        public int Id { get; set; }
    }
}
