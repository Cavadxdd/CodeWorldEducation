using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeWorldEducation.Application.Common.Announcement
{
    public class AnnouncementListDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime PublishedAt { get; set; }
    }
}
