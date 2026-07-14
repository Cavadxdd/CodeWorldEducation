using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MediatR;

namespace CodeWorldEducation.Application.Features.Events.Queries.GetEventById;

public class GetEventByIdQueryRequest : IRequest<GetEventByIdQueryResponse>
{
    public int Id { get; set; }
}
