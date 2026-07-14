using CodeWorldEducation.Application.Abstraction.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeWorldEducation.Application.Features.Mentors.Commands.Update
{
    public class UpdateMentorCommandHandler
    : IRequestHandler<UpdateMentorCommandRequest, UpdateMentorCommandResponse>
    {
        private readonly IMentorService _mentorService;

        public UpdateMentorCommandHandler(IMentorService mentorService)
        {
            _mentorService = mentorService;
        }

        public async Task<UpdateMentorCommandResponse> Handle(
            UpdateMentorCommandRequest request,
            CancellationToken cancellationToken)
        {
            var result = await _mentorService.UpdateAsync(request.Id, request.Mentor);
            return new UpdateMentorCommandResponse { Mentor = result };
        }
    }
}
