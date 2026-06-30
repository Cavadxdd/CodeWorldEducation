using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MediatR;
using CodeWorldEducation.Application.Abstraction.Services;

namespace CodeWorldEducation.Application.Features.Events.Commands.UpdateEvent;

public class UpdateEventCommandHandler
    : IRequestHandler<UpdateEventCommandRequest, UpdateEventCommandResponse>
{
    private readonly IEventService _eventService;

    public UpdateEventCommandHandler(IEventService eventService)
    {
        _eventService = eventService;
    }

    public async Task<UpdateEventCommandResponse> Handle(
        UpdateEventCommandRequest request,
        CancellationToken cancellationToken)
    {
        return await _eventService.UpdateAsync(request);
    }
}
