using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MediatR;
using CodeWorldEducation.Application.Abstraction.Services;

namespace CodeWorldEducation.Application.Features.Announcements.Commands.UpdateAnnouncement;

public class UpdateAnnouncementCommandHandler
    : IRequestHandler<UpdateAnnouncementCommandRequest, UpdateAnnouncementCommandResponse>
{
    private readonly IAnnouncementService _announcementService;

    public UpdateAnnouncementCommandHandler(IAnnouncementService announcementService)
    {
        _announcementService = announcementService;
    }

    public async Task<UpdateAnnouncementCommandResponse> Handle(
        UpdateAnnouncementCommandRequest request,
        CancellationToken cancellationToken)
    {
        return await _announcementService.UpdateAsync(request);
    }
}