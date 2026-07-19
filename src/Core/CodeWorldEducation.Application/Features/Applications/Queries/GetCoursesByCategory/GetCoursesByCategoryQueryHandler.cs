using CodeWorldEducation.Application.Abstraction.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeWorldEducation.Application.Features.Applications.Queries.GetCoursesByCategory
{
    public class GetCoursesByCategoryQueryHandler : IRequestHandler<GetCoursesByCategoryQueryRequest, GetCoursesByCategoryQueryResponse>
    {
        private readonly ICourseService _courseService;

        public GetCoursesByCategoryQueryHandler(ICourseService courseService)
        {
            _courseService = courseService;
        }

        public async Task<GetCoursesByCategoryQueryResponse> Handle(
            GetCoursesByCategoryQueryRequest request,
            CancellationToken cancellationToken)
        {
            var result = await _courseService.GetByCategoryAsync(request.CategoryId);
            return new GetCoursesByCategoryQueryResponse { Courses = result };
        }
    }
}
