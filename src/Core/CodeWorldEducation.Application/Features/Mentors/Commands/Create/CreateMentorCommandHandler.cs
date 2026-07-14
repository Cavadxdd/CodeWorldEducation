using CodeWorldEducation.Application.Abstraction.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeWorldEducation.Application.Features.Mentors.Commands.Create
{
    public class CreateMentorCommandHandler
    : IRequestHandler<CreateMentorCommandRequest, CreateMentorCommandResponse>
    {
        private readonly IMentorService _mentorService;

        public CreateMentorCommandHandler(IMentorService mentorService)
        {
            _mentorService = mentorService;
        }

        public async Task<CreateMentorCommandResponse> Handle(
            CreateMentorCommandRequest request,
            CancellationToken cancellationToken)
        {
            var result = await _mentorService.CreateAsync(request.Dto);
            return new CreateMentorCommandResponse { Mentor = result };
        }
    }
}
