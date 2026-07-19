using CodeWorldEducation.Application.Common.Mentor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeWorldEducation.Application.Features.Mentors.Queries.GetAllMentors
{
    public class GetAllMentorsQueryResponse
    {
        public List<GetMentorDto> Mentors { get; set; }
    }
}
