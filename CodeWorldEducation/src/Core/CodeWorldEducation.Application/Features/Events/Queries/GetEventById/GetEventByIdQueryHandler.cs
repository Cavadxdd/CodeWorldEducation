using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MediatR;
using CodeWorldEducation.Application.Abstraction.Services;

namespace CodeWorldEducation.Application.Features.Events.Queries.GetEventById;

public class GetEventByIdQueryHandler
    : IRequestHandler<GetEventByIdQueryRequest, GetEventByIdQueryResponse>
{
    private readonly IEventService _eventService;

    public GetEventByIdQueryHandler(IEventService eventService)
    {
        _eventService = eventService;
    }

    public async Task<GetEventByIdQueryResponse> Handle(
        GetEventByIdQueryRequest request,
        CancellationToken cancellationToken)
    {
        var ev = await _eventService.GetByIdAsync(request.Id);
        return new GetEventByIdQueryResponse { Event = ev };
    }
}
