using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MediatR;
using CodeWorldEducation.Application.Abstraction.Services;

namespace CodeWorldEducation.Application.Features.Announcements.Commands.DeleteAnnouncement;

public class DeleteAnnouncementCommandHandler
    : IRequestHandler<DeleteAnnouncementCommandRequest, DeleteAnnouncementCommandResponse>
{
    private readonly IAnnouncementService _announcementService;

    public DeleteAnnouncementCommandHandler(IAnnouncementService announcementService)
    {
        _announcementService = announcementService;
    }

    public async Task<DeleteAnnouncementCommandResponse> Handle(
        DeleteAnnouncementCommandRequest request,
        CancellationToken cancellationToken)
    {
        return await _announcementService.DeleteAsync(request.Id);
    }
}
