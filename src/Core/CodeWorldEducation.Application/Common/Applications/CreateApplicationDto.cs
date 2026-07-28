using CodeWorldEducation.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace CodeWorldEducation.Application.Common.Applications
{
    public class CreateApplicationDto
    {
        public string FullName { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public ApplicantType ApplicantType { get; set; }
        public int CourseId { get; set; }
        public TeachingMode? EducationMode { get; set; }
        public string? BehanceUrl { get; set; }
        public string? DribbbleUrl { get; set; }
        public IFormFile? CvFile { get; set; }
        public string? Note { get; set; }
    }
}
