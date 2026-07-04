using CodeWorldEducation.Application.Abstraction.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeWorldEducation.Application.Features.Courses.Queries.GetCourseById
{
    public class GetCourseByIdQueryHandler : IRequestHandler<GetCourseByIdQueryRequest, GetCourseByIdQueryResponse>
    {
        private readonly ICourseService _courseService;

        public GetCourseByIdQueryHandler(ICourseService courseService)
        {
            _courseService = courseService;
        }

        public async Task<GetCourseByIdQueryResponse> Handle(
            GetCourseByIdQueryRequest request,
            CancellationToken cancellationToken)
        {
            var result = await _courseService.GetByIdAsync(request.Id);
            return new GetCourseByIdQueryResponse { Course = result };
        }
    }
}
