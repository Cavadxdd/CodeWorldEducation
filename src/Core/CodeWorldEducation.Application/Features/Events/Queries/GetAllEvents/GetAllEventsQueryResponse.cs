using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CodeWorldEducation.Domain.Entities;

namespace CodeWorldEducation.Application.Features.Events.Queries.GetAllEvents;

public class GetAllEventsQueryResponse
{
    public List<Event> Events { get; set; } = new();
}
