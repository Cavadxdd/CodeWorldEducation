using CodeWorldEducation.Application.Common.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeWorldEducation.Application.Features.Applications.Queries.GetAll
{
    public class GetAllApplicationsQueryResponse
    {
        public List<GetApplicationDto> Applications { get; set; }
    }
}
