using CodeWorldEducation.Application.Abstraction.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeWorldEducation.Application.Features.Mentors.Queries.GetMentorCourses
{
    public class GetMentorCoursesQueryHandler
    : IRequestHandler<GetMentorCoursesQueryRequest, GetMentorCoursesQueryResponse>
    {
        private readonly IMentorService _mentorService;

        public GetMentorCoursesQueryHandler(IMentorService mentorService)
        {
            _mentorService = mentorService;
        }

        public async Task<GetMentorCoursesQueryResponse> Handle(
            GetMentorCoursesQueryRequest request,
            CancellationToken cancellationToken)
        {
            var result = await _mentorService.GetMentorCoursesAsync(request.MentorId);
            return new GetMentorCoursesQueryResponse { Courses = result };
        }
    }
}
