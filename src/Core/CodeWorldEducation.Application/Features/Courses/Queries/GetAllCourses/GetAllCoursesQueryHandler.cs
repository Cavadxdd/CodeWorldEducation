using CodeWorldEducation.Application.Abstraction.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeWorldEducation.Application.Features.Courses.Queries.GetAllCourses
{
    public class GetAllCoursesQueryHandler : IRequestHandler<GetAllCoursesQueryRequest, GetAllCoursesQueryResponse>
    {
        private readonly ICourseService _courseService;

        public GetAllCoursesQueryHandler(ICourseService courseService)
        {
            _courseService = courseService;
        }

        public async Task<GetAllCoursesQueryResponse> Handle(
            GetAllCoursesQueryRequest request,
            CancellationToken cancellationToken)
        {
            var result = await _courseService.GetAllAsync();
            return new GetAllCoursesQueryResponse { Courses = result };
        }
    }
}
