using CodeWorldEducation.Application.Features.Endpoints.Queries.GetAllEndpoints;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeWorldEducation.Application.Abstraction.Services
{
    public interface IAuthorizationEndpointService
    {
        Task<List<GetAllAuthorizationEndpointsQueryResponse>> GetAllAsync();
        Task AssignRolesAsync(string endpointCode, List<string> roles);
    }
}
