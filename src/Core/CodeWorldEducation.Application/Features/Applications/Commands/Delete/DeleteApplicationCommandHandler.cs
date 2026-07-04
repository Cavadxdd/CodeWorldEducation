using CodeWorldEducation.Application.Abstraction.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeWorldEducation.Application.Features.Applications.Commands.Delete
{
    public class DeleteApplicationCommandHandler
    : IRequestHandler<DeleteApplicationCommandRequest, DeleteApplicationCommandResponse>
    {
        private readonly IApplicationService _applicationService;

        public DeleteApplicationCommandHandler(IApplicationService applicationService)
        {
            _applicationService = applicationService;
        }

        public async Task<DeleteApplicationCommandResponse> Handle(
            DeleteApplicationCommandRequest request,
            CancellationToken cancellationToken)
        {
            await _applicationService.DeleteAsync(request.Id);
            return new DeleteApplicationCommandResponse
            {
                Success = true,
                Message = "Application deleted successfully"
            };
        }
    }
}
