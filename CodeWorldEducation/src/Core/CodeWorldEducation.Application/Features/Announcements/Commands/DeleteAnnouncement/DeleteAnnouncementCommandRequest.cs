using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MediatR;

namespace CodeWorldEducation.Application.Features.Announcements.Commands.DeleteAnnouncement;

public class DeleteAnnouncementCommandRequest : IRequest<DeleteAnnouncementCommandResponse>
{
    public int Id { get; set; }
}
