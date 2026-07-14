using CodeWorldEducation.Application.Abstraction.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeWorldEducation.Application.Features.Mentors.Queries.GetAllMentors
{
    public class GetAllMentorsQueryHandler
    : IRequestHandler<GetAllMentorsQueryRequest, GetAllMentorsQueryResponse>
    {
        private readonly IMentorService _mentorService;

        public GetAllMentorsQueryHandler(IMentorService mentorService)
        {
            _mentorService = mentorService;
        }

        public async Task<GetAllMentorsQueryResponse> Handle(
            GetAllMentorsQueryRequest request,
            CancellationToken cancellationToken)
        {
            var result = await _mentorService.GetAllAsync();
            return new GetAllMentorsQueryResponse { Mentors = result };
        }
    }
}
