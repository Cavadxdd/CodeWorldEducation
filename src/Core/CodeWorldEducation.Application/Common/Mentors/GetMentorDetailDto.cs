using CodeWorldEducation.Application.Common.Courses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeWorldEducation.Application.Common.Mentors
{
    public class GetMentorDetailDto
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Position { get; set; }
        public string PhotoUrl { get; set; }
        public string? LinkedInUrl { get; set; }
        public List<string> Technologies { get; set; }
        public string? Bio { get; set; }
        public List<GetCourseListDto> Courses { get; set; }
    }
}
