using CodeWorldEducation.Application.Abstraction.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeWorldEducation.Application.Features.Applications.Commands.Update
{
    public class UpdateApplicationCommandHandler
    : IRequestHandler<UpdateApplicationCommandRequest, UpdateApplicationCommandResponse>
    {
        private readonly IApplicationService _applicationService;

        public UpdateApplicationCommandHandler(IApplicationService applicationService)
        {
            _applicationService = applicationService;
        }

        public async Task<UpdateApplicationCommandResponse> Handle(
            UpdateApplicationCommandRequest request,
            CancellationToken cancellationToken)
        {
            var result = await _applicationService.UpdateAsync(request.Dto);
            return new UpdateApplicationCommandResponse { Application = result };
        }
    }
}
