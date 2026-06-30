using CodeWorldEducation.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeWorldEducation.Application.Common.Course
{
    public class UpdateCourseDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Slug { get; set; }
        public string Description { get; set; }
        public string Duration { get; set; }
        public string Intensity { get; set; }
        public TeachingMode TeachingMode { get; set; }
        public string? ThumbnailUrl { get; set; }
        public int CategoryId { get; set; }
        public int SortOrder { get; set; }
        public bool IsActive { get; set; }
    }
}
