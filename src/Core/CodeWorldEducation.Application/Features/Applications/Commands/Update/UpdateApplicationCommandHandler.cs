using CodeWorldEducation.Application.Abstraction.Services;
using MediatR;

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
            if (request.Dto.Status == Domain.Enums.ApplicationStatus.Approved)
                await _applicationService.ApproveAsync(request.Dto.Id, request.Dto.ReviewedBy ?? "Admin");
            else
                await _applicationService.RejectAsync(request.Dto.Id, request.Dto.ReviewedBy ?? "Admin");

            return new UpdateApplicationCommandResponse { Success = true, Message = "Status yeniləndi." };
        }
    }
}