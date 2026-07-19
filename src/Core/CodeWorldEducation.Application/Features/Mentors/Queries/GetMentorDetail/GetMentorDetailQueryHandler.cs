using CodeWorldEducation.Application.Abstraction.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeWorldEducation.Application.Features.Mentors.Queries.GetMentorDetail
{
    public class GetMentorDetailQueryHandler
    : IRequestHandler<GetMentorDetailQueryRequest, GetMentorDetailQueryResponse>
    {
        private readonly IMentorService _mentorService;

        public GetMentorDetailQueryHandler(IMentorService mentorService)
        {
            _mentorService = mentorService;
        }

        public async Task<GetMentorDetailQueryResponse> Handle(
            GetMentorDetailQueryRequest request,
            CancellationToken cancellationToken)
        {
            var result = await _mentorService.GetDetailAsync(request.Id);
            return new GetMentorDetailQueryResponse { Mentor = result };
        }
    }
}
