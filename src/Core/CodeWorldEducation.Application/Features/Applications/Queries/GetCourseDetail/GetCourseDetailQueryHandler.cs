using CodeWorldEducation.Application.Abstraction.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeWorldEducation.Application.Features.Applications.Queries.GetCourseDetail
{
    public class GetCourseDetailQueryHandler
    : IRequestHandler<GetCourseDetailQueryRequest, GetCourseDetailQueryResponse>
    {
        private readonly ICourseService _courseService;

        public GetCourseDetailQueryHandler(ICourseService courseService)
        {
            _courseService = courseService;
        }

        public async Task<GetCourseDetailQueryResponse> Handle(
            GetCourseDetailQueryRequest request,
            CancellationToken cancellationToken)
        {
            var result = await _courseService.GetDetailBySlugAsync(request.Slug);
            return new GetCourseDetailQueryResponse { Course = result };
        }
    }
}
