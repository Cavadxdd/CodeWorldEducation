using CodeWorldEducation.Application.Abstraction.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeWorldEducation.Application.Features.Applications.Commands.Create
{
    public class CreateApplicationCommandHandler : IRequestHandler<CreateApplicationCommandRequest, CreateApplicationCommandResponse>
    {
        private readonly IApplicationService _applicationService;

        public CreateApplicationCommandHandler(IApplicationService applicationService)
        {
            _applicationService = applicationService;
        }

        public async Task<CreateApplicationCommandResponse> Handle(
            CreateApplicationCommandRequest request,
            CancellationToken cancellationToken)
        {
            var result = await _applicationService.CreateAsync(request.Dto);
            return new CreateApplicationCommandResponse { Application = result };
        }
    }
}
