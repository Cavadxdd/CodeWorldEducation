using CodeWorldEducation.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeWorldEducation.Domain.Entities
{
    public class Mentor : BaseEntity
    {
        public string FullName { get; set; }
        public string Position { get; set; }
        public string PhotoUrl { get; set; }
        public string? LinkedInUrl { get; set; }
        public string Technologies { get; set; } // JSON array: ["C#","ASP.NET","SQL"]
        public string? Bio { get; set; }
        public bool IsActive { get; set; }
        public int SortOrder { get; set; }

        public ICollection<MentorCourse> MentorCourses { get; set; }
    }
}
