using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeWorldEducation.Application.Features.Mentors.Queries.GetMentorCourses
{
    public class GetMentorCoursesQueryRequest : IRequest<GetMentorCoursesQueryResponse>
    {
        public int MentorId { get; set; }
    }
}
