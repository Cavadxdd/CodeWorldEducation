using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using CodeWorldEducation.Application.Abstraction.Services;

namespace CodeWorldEducation.Application.Features.Announcements.Commands.CreateAnnouncement;

public class CreateAnnouncementCommandHandler : IRequestHandler<CreateAnnouncementCommandRequest, CreateAnnouncementCommandResponse>
{
    private readonly IAnnouncementService _announcementService;

    public CreateAnnouncementCommandHandler(IAnnouncementService announcementService)
    {
        _announcementService = announcementService;
    }

    public async Task<CreateAnnouncementCommandResponse> Handle(CreateAnnouncementCommandRequest request, CancellationToken cancellationToken)
    {
        return await _announcementService.CreateAsync(request);
    }
}
