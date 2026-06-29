using CodeWorldEducation.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeWorldEducation.Application.Common.Application
{
    public class CreateApplicationDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public ApplicantType ApplicantType { get; set; }
        public int? CourseId { get; set; }
        public string? Field { get; set; }
        public TeachingMode? TeachingMode { get; set; }
        public string? GitHubUrl { get; set; }
        public string? BehanceUrl { get; set; }
    }
}
