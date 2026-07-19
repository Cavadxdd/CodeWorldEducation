using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeWorldEducation.Application.Features.Mentors.Queries.GetMentorDetail
{
    public class GetMentorDetailQueryRequest : IRequest<GetMentorDetailQueryResponse>
    {
        public int Id { get; set; }
    }
}
