using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MediatR;

namespace CodeWorldEducation.Application.Features.Announcements.Queries.GetAnnouncementById;

public class GetAnnouncementByIdQueryRequest : IRequest<GetAnnouncementByIdQueryResponse>
{
    public int Id { get; set; }
}
