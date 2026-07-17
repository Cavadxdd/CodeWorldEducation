using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeWorldEducation.Application.Features.Endpoints.Queries.GetAllEndpoints
{
    public class GetAllAuthorizationEndpointsQueryRequest : IRequest<List<GetAllAuthorizationEndpointsQueryResponse>>
    {
    }
}
