using CodeWorldEducation.Application.Abstraction.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeWorldEducation.Application.Features.Courses.Commands.Create
{
    public class CreateCourseCommandHandler : IRequestHandler<CreateCourseCommandRequest, CreateCourseCommandResponse>
    {
        private readonly ICourseService _courseService;

        public CreateCourseCommandHandler(ICourseService courseService)
        {
            _courseService = courseService;
        }

        public async Task<CreateCourseCommandResponse> Handle(
            CreateCourseCommandRequest request,
            CancellationToken cancellationToken)
        {
            var result = await _courseService.CreateAsync(request.Dto);
            return new CreateCourseCommandResponse { Course = result };
        }
    }
}
