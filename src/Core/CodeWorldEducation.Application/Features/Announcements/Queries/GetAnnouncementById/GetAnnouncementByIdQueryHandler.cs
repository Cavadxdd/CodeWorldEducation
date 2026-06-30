using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using CodeWorldEducation.Application.Abstraction.Services;

namespace CodeWorldEducation.Application.Features.Announcements.Queries.GetAnnouncementById;

public class GetAnnouncementByIdQueryHandler
    : IRequestHandler<GetAnnouncementByIdQueryRequest, GetAnnouncementByIdQueryResponse>
{
    private readonly IAnnouncementService _announcementService;

    public GetAnnouncementByIdQueryHandler(IAnnouncementService announcementService)
    {
        _announcementService = announcementService;
    }

    public async Task<GetAnnouncementByIdQueryResponse> Handle(
        GetAnnouncementByIdQueryRequest request,
        CancellationToken cancellationToken)
    {
        var announcement = await _announcementService.GetByIdAsync(request.Id);
        return new GetAnnouncementByIdQueryResponse { Announcement = announcement };
    }
}
