using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MediatR;

namespace CodeWorldEducation.Application.Features.Announcements.Commands.UpdateAnnouncement;

public class UpdateAnnouncementCommandRequest : IRequest<UpdateAnnouncementCommandResponse>
{
    public int Id { get; set; }
    public string Title { get; set; } = null!;
    public string Content { get; set; } = null!;
}
