using CodeWorldEducation.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeWorldEducation.Application.Common.Courses
{
    public class GetCourseListDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Slug { get; set; }
        public string Duration { get; set; }
        public TeachingMode TeachingMode { get; set; }
        public string? ThumbnailUrl { get; set; }
        public string CategoryName { get; set; }
    }
}
