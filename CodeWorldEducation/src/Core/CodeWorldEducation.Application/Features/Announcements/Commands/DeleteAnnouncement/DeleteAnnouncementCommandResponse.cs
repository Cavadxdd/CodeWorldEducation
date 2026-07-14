using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeWorldEducation.Application.Features.Announcements.Commands.DeleteAnnouncement;

public class DeleteAnnouncementCommandResponse
{
    public bool Success { get; set; }
    public string Message { get; set; } = null!;
}
