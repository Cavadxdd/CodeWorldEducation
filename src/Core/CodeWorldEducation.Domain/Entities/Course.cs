using CodeWorldEducation.Domain.Entities.Common;
using CodeWorldEducation.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeWorldEducation.Domain.Entities
{
    public class Course:BaseEntity
    {
        public string Name { get; set; }
        public string Slug { get; set; }
        public string Description { get; set; }
        public string Duration { get; set; }
        public string Intensity { get; set; }
        public TeachingMode TeachingMode { get; set; }
        public string? ThumbnailUrl { get; set; }
        public bool IsActive { get; set; }
        public int SortOrder { get; set; }
        public int CategoryId { get; set; }

        public Category Category { get; set; }
        public ICollection<SyllabusItem> SyllabusItems { get; set; }
        public ICollection<MentorCourse> MentorCourses { get; set; }
        public ICollection<Alumni> Alumni { get; set; }
        public ICollection<Application> Applications { get; set; }


    }
}
