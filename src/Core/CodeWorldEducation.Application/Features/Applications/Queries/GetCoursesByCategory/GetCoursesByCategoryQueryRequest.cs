using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeWorldEducation.Application.Features.Applications.Queries.GetCoursesByCategory
{
    public class GetCoursesByCategoryQueryRequest : IRequest<GetCoursesByCategoryQueryResponse>
    {
        public int CategoryId { get; set; }
    }
}
