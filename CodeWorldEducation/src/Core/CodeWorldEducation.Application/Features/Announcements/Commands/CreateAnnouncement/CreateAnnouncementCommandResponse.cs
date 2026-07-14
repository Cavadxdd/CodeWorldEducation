using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeWorldEducation.Application.Features.Announcements.Commands.CreateAnnouncement;

public class CreateAnnouncementCommandResponse
{
    public bool Success { get; set; }
    public string Message { get; set; } = null!;
}
