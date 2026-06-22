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
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhotoUrl { get; set; }
        public string Designation {  get; set; }
        public string LinkedinUrl { get; set; }
        public ICollection<MentorCourse> MentorCourses { get; set; }
        public ICollection<MentorTechnology> Technologies { get; set; }
    }
}
