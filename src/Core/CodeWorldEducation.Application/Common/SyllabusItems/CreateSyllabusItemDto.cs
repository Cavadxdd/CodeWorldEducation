using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeWorldEducation.Application.Common.SyllabusItem
{
    public class CreateSyllabusItemDto
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public int OrderIndex { get; set; }
        public int? WeekNumber { get; set; }
        public int CourseId { get; set; }
    }
}
