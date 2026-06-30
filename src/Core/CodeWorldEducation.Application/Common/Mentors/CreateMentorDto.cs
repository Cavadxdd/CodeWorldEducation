using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeWorldEducation.Application.Common.Mentors
{
    public class CreateMentorDto
    {
        public string FullName { get; set; }
        public string Position { get; set; }
        public string PhotoUrl { get; set; }
        public string? LinkedInUrl { get; set; }
        public List<string> Technologies { get; set; }
        public string? Bio { get; set; }
        public int SortOrder { get; set; }
    }
}
