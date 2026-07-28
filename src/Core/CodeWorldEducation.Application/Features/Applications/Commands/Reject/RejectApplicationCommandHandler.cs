using CodeWorldEducation.Application.Abstraction.Services;
using MediatR;

namespace CodeWorldEducation.Application.Features.Applications.Commands.Reject
{
    public class RejectApplicationCommandHandler
        : IRequestHandler<RejectApplicationCommandRequest, RejectApplicationCommandResponse>
    {
        private readonly IApplicationService _applicationService;

        public RejectApplicationCommandHandler(IApplicationService applicationService)
        {
            _applicationService = applicationService;
        }

        public async Task<RejectApplicationCommandResponse> Handle(
            RejectApplicationCommandRequest request,
            CancellationToken cancellationToken)
        {
            var result = await _applicationService.RejectAsync(request.Id, request.ReviewedBy);
            return new RejectApplicationCommandResponse
            {
                Success = true,
                Message = "Müraciət rədd edildi.",
                Application = result
            };
        }
    }
}