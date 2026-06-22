using CodeWorldEducation.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeWorldEducation.Domain.Entities
{
    public class SyllabusItem : BaseEntity
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public int OrderIndex { get; set; }
        public int CourseId { get; set; }

        public Course Course { get; set; }
    }
}
