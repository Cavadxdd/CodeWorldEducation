using CodeWorldEducation.Application.Abstraction.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeWorldEducation.Application.Features.Applications.Queries.GetById
{
    public class GetApplicationByIdQueryHandler
    : IRequestHandler<GetApplicationByIdQueryRequest, GetApplicationByIdQueryResponse>
    {
        private readonly IApplicationService _applicationService;

        public GetApplicationByIdQueryHandler(IApplicationService applicationService)
        {
            _applicationService = applicationService;
        }

        public async Task<GetApplicationByIdQueryResponse> Handle(
            GetApplicationByIdQueryRequest request,
            CancellationToken cancellationToken)
        {
            var result = await _applicationService.GetByIdAsync(request.Id);
            return new GetApplicationByIdQueryResponse { Application = result };
        }
    }
}
