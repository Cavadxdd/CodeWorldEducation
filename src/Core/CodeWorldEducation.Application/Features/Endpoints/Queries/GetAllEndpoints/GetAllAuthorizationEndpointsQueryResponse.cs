using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeWorldEducation.Application.Features.Endpoints.Queries.GetAllEndpoints
{
    public class GetAllAuthorizationEndpointsQueryResponse
    {
        public string Code { get; set; } = null!;
        public string Definition { get; set; } = null!;
        public string HttpMethod { get; set; } = null!;
        public string Controller { get; set; } = null!;
        public string ActionType { get; set; } = null!;

        public List<string> Roles { get; set; } = new();
    }
}
