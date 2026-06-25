using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MediatR;
using CodeWorldEducation.Application.Abstraction.Services;

namespace CodeWorldEducation.Application.Features.Events.Queries.GetAllEvents;

public class GetAllEventsQueryHandler
    : IRequestHandler<GetAllEventsQueryRequest, GetAllEventsQueryResponse>
{
    private readonly IEventService _eventService;

    public GetAllEventsQueryHandler(IEventService eventService)
    {
        _eventService = eventService;
    }

    public async Task<GetAllEventsQueryResponse> Handle(
        GetAllEventsQueryRequest request,
        CancellationToken cancellationToken)
    {
        var events = await _eventService.GetAllAsync();
        return new GetAllEventsQueryResponse { Events = events };
    }
}