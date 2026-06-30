using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeWorldEducation.Application.Common.Announcement
{
    public class CreateAnnouncementDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime PublishedAt { get; set; }
    }
}
