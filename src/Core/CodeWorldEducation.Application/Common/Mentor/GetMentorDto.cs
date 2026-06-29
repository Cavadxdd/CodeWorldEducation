using CodeWorldEducation.Application.Common.MentorTechnology;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeWorldEducation.Application.Common.Mentor
{
    public class GetMentorDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhotoUrl { get; set; }
        public string Designation { get; set; }
        public string LinkedInUrl { get; set; }
        public List<GetMentorTechnologyDto> Technologies { get; set; }
    }
}
