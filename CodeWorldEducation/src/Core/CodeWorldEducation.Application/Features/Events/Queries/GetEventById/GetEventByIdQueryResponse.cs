using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CodeWorldEducation.Domain.Entities;

namespace CodeWorldEducation.Application.Features.Events.Queries.GetEventById;

public class GetEventByIdQueryResponse
{
    public Event? Event { get; set; }
}
