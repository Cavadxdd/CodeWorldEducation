using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MediatR;

namespace CodeWorldEducation.Application.Features.Announcements.Commands.CreateAnnouncement;

public class CreateAnnouncementCommandRequest : IRequest<CreateAnnouncementCommandResponse>
{
    public string Title { get; set; } = null!;
    public string Content { get; set; } = null!;
}