using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MediatR;
using CodeWorldEducation.Application.Abstraction.Services;

namespace CodeWorldEducation.Application.Features.Events.Commands.CreateEvent;

public class CreateEventCommandHandler
    : IRequestHandler<CreateEventCommandRequest, CreateEventCommandResponse>
{
    private readonly IEventService _eventService;

    public CreateEventCommandHandler(IEventService eventService)
    {
        _eventService = eventService;
    }

    public async Task<CreateEventCommandResponse> Handle(
        CreateEventCommandRequest request,
        CancellationToken cancellationToken)
    {
        return await _eventService.CreateAsync(request);
    }
}
