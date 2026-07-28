using CodeWorldEducation.Application.Abstraction.Services;
using MediatR;

namespace CodeWorldEducation.Application.Features.Applications.Commands.Approve
{
    public class ApproveApplicationCommandHandler
        : IRequestHandler<ApproveApplicationCommandRequest, ApproveApplicationCommandResponse>
    {
        private readonly IApplicationService _applicationService;

        public ApproveApplicationCommandHandler(IApplicationService applicationService)
        {
            _applicationService = applicationService;
        }

        public async Task<ApproveApplicationCommandResponse> Handle(
            ApproveApplicationCommandRequest request,
            CancellationToken cancellationToken)
        {
            var result = await _applicationService.ApproveAsync(request.Id, request.ReviewedBy);
            return new ApproveApplicationCommandResponse
            {
                Success = true,
                Message = "Müraciət təsdiqləndi.",
                Application = result
            };
        }
    }
}