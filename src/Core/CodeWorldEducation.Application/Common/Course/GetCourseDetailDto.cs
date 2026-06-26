using CodeWorldEducation.Application.Common.Mentor;
using CodeWorldEducation.Application.Common.SyllabusItem;
using CodeWorldEducation.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeWorldEducation.Application.Common.Courses
{
    public class GetCourseDetailDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string DetailedDescription { get; set; }
        public string Duration { get; set; }
        public string Intensity { get; set; }
        public TeachingMode TeachingMode { get; set; }
        public string CategoryName { get; set; }
        public List<GetSyllabusItemDto> SyllabusItems { get; set; }
        public List<GetMentorDto> Mentors { get; set; }
    }
}
