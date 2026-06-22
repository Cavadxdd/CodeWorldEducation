using CodeWorldEducation.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeWorldEducation.Domain.Entities
{
    public class MentorCourse : BaseEntity
    {
        public int MentorId { get; set; }
        public int CourseId { get; set; }
        public Mentor Mentor { get; set; }
        public Course Course { get; set; }
    }
}
