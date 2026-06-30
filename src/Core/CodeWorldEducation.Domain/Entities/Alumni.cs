using CodeWorldEducation.Domain.Entities.Common;
using CodeWorldEducation.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeWorldEducation.Domain.Entities
{
    public class Alumni : BaseEntity
    {
        public string FullName { get; set; }
        public string? PhotoUrl { get; set; }
        public AlumniType AlumniType { get; set; }
        public string CompletedCourse { get; set; }
        public string? CurrentCompany { get; set; }
        public string? CurrentPosition { get; set; }
        public string? GitHubUrl { get; set; }
        public string? BehanceUrl { get; set; }
        public string? ProjectUrl { get; set; }
        public string? Testimonial { get; set; }
        public bool IsActive { get; set; }
        public DateTime? GraduatedAt { get; set; }
    }
}
