using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CodeWorldEducation.Domain.Entities;

namespace CodeWorldEducation.Application.Features.Announcements.Queries.GetAnnouncementById;

public class GetAnnouncementByIdQueryResponse
{
    public Announcement? Announcement { get; set; }
}