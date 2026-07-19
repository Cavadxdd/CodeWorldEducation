using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeWorldEducation.Application.Features.Alumni.Queries.GetAlumniDetail
{
    
    public class GetAlumniDetailQueryRequest : IRequest<GetAlumniDetailQueryResponse>
    {
        public int Id { get; set; }
    }
}
