using CodeWorldEducation.Application.Abstraction.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeWorldEducation.Application.Features.Courses.Commands.Delete
{
    public class DeleteCourseCommandHandler : IRequestHandler<DeleteCourseCommandRequest, DeleteCourseCommandResponse>
    {
        private readonly ICourseService _courseService;

        public DeleteCourseCommandHandler(ICourseService courseService)
        {
            _courseService = courseService;
        }

        public async Task<DeleteCourseCommandResponse> Handle(
            DeleteCourseCommandRequest request,
            CancellationToken cancellationToken)
        {
            await _courseService.DeleteAsync(request.Id);
            return new DeleteCourseCommandResponse
            {
                Success = true,
                Message = "Course deleted successfully"
            };
        }
    }
}
