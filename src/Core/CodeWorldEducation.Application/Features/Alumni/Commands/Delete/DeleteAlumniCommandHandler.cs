using CodeWorldEducation.Application.Abstraction.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeWorldEducation.Application.Features.Alumni.Commands.Delete
{
    public class DeleteAlumniCommandHandler
    : IRequestHandler<DeleteAlumniCommandRequest, DeleteAlumniCommandResponse>
    {
        private readonly IAlumniService _alumniService;

        public DeleteAlumniCommandHandler(IAlumniService alumniService)
        {
            _alumniService = alumniService;
        }

        public async Task<DeleteAlumniCommandResponse> Handle(
            DeleteAlumniCommandRequest request,
            CancellationToken cancellationToken)
        {
            await _alumniService.DeleteAsync(request.Id);
            return new DeleteAlumniCommandResponse
            {
                Success = true,
                Message = "Alumni deleted successfully"
            };
        }
    }
}
