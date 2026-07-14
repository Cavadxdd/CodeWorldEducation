using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MediatR;
using CodeWorldEducation.Application.Abstraction.Services;

namespace CodeWorldEducation.Application.Features.Announcements.Queries.GetAllAnnouncements;

public class GetAllAnnouncementsQueryHandler
    : IRequestHandler<GetAllAnnouncementsQueryRequest, GetAllAnnouncementsQueryResponse>
{
    private readonly IAnnouncementService _announcementService;

    public GetAllAnnouncementsQueryHandler(IAnnouncementService announcementService)
    {
        _announcementService = announcementService;
    }

    public async Task<GetAllAnnouncementsQueryResponse> Handle(
        GetAllAnnouncementsQueryRequest request,
        CancellationToken cancellationToken)
    {
        var announcements = await _announcementService.GetAllAsync();
        return new GetAllAnnouncementsQueryResponse { Announcements = announcements };
    }
}
