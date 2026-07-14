using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MediatR;
using CodeWorldEducation.Application.Abstraction.Services;

namespace CodeWorldEducation.Application.Features.Events.Commands.DeleteEvent;

public class DeleteEventCommandHandler
    : IRequestHandler<DeleteEventCommandRequest, DeleteEventCommandResponse>
{
    private readonly IEventService _eventService;

    public DeleteEventCommandHandler(IEventService eventService)
    {
        _eventService = eventService;
    }

    public async Task<DeleteEventCommandResponse> Handle(
        DeleteEventCommandRequest request,
        CancellationToken cancellationToken)
    {
        return await _eventService.DeleteAsync(request.Id);
    }
}
