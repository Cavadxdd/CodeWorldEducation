using CodeWorldEducation.Application.Abstraction.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeWorldEducation.Application.Features.Mentors.Commands.Delete
{
    public class DeleteMentorCommandHandler
    : IRequestHandler<DeleteMentorCommandRequest, DeleteMentorCommandResponse>
    {
        private readonly IMentorService _mentorService;

        public DeleteMentorCommandHandler(IMentorService mentorService)
        {
            _mentorService = mentorService;
        }

        public async Task<DeleteMentorCommandResponse> Handle(
            DeleteMentorCommandRequest request,
            CancellationToken cancellationToken)
        {
            await _mentorService.DeleteAsync(request.Id);
            return new DeleteMentorCommandResponse
            {
                Success = true,
                Message = "Mentor deleted successfully"
            };
        }
    }
}
