using CodeWorldEducation.Application.Abstraction.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeWorldEducation.Application.Features.Endpoints.Queries.GetAllEndpoints
{
    public class GetAllAuthorizationEndpointsQueryHandler
    : IRequestHandler<GetAllAuthorizationEndpointsQueryRequest, List<GetAllAuthorizationEndpointsQueryResponse>>
    {
        private readonly IAuthorizationEndpointService _authorizationEndpointService;

        public GetAllAuthorizationEndpointsQueryHandler(
            IAuthorizationEndpointService authorizationEndpointService)
        {
            _authorizationEndpointService = authorizationEndpointService;
        }

        public async Task<List<GetAllAuthorizationEndpointsQueryResponse>> Handle(
            GetAllAuthorizationEndpointsQueryRequest request,
            CancellationToken cancellationToken)
        {
            return await _authorizationEndpointService.GetAllAsync();
        }
    }
}
