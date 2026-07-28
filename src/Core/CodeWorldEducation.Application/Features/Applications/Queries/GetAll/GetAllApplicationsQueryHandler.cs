using CodeWorldEducation.Application.Abstraction.Services;
using MediatR;

namespace CodeWorldEducation.Application.Features.Applications.Queries.GetAll
{
    public class GetAllApplicationsQueryHandler
        : IRequestHandler<GetAllApplicationsQueryRequest, GetAllApplicationsQueryResponse>
    {
        private readonly IApplicationService _applicationService;

        public GetAllApplicationsQueryHandler(IApplicationService applicationService)
        {
            _applicationService = applicationService;
        }

        public async Task<GetAllApplicationsQueryResponse> Handle(
            GetAllApplicationsQueryRequest request,
            CancellationToken cancellationToken)
        {
            var result = await _applicationService.GetAllAsync(request.Type, request.Status);
            return new GetAllApplicationsQueryResponse { Applications = result };
        }
    }
}