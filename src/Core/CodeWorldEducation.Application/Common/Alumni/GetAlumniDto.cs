using CodeWorldEducation.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeWorldEducation.Application.Common.Alumni
{
    public class GetAlumniDto
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string? PhotoUrl { get; set; }
        public AlumniType AlumniType { get; set; }
        public string CompletedCourse { get; set; }
        public string? CurrentCompany { get; set; }
        public string? CurrentPosition { get; set; }
        public string? Testimonial { get; set; }
    }
}
