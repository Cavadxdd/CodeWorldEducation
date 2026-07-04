using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeWorldEducation.Application.Features.Applications.Queries.GetById
{
    public class GetApplicationByIdQueryRequest : IRequest<GetApplicationByIdQueryResponse>
    {
        public int Id { get; set; }
    }
}
