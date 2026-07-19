using CodeWorldEducation.Application.Abstraction.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeWorldEducation.Application.Features.Courses.Commands.Update
{
    public class UpdateCourseCommandHandler : IRequestHandler<UpdateCourseCommandRequest, UpdateCourseCommandResponse>
    {
        private readonly ICourseService _courseService;

        public UpdateCourseCommandHandler(ICourseService courseService)
        {
            _courseService = courseService;
        }

        public async Task<UpdateCourseCommandResponse> Handle(
            UpdateCourseCommandRequest request,
            CancellationToken cancellationToken)
        {
            var result = await _courseService.UpdateAsync(request.Id,request.Dto);
            return new UpdateCourseCommandResponse { Course = result };
        }
    }
}
