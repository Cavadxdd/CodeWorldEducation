using CodeWorldEducation.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeWorldEducation.Application.Common.Applications
{
    public class GetApplicationDto
    {
        public int Id { get; set; }
        public string FullName { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public ApplicantType ApplicantType { get; set; }
        public int CourseId { get; set; }
        public string? CourseName { get; set; }
        public TeachingMode? EducationMode { get; set; }
        public string? BehanceUrl { get; set; }
        public string? DribbbleUrl { get; set; }
        public string? CvFilePath { get; set; }
        public string? Note { get; set; }
        public ApplicationStatus Status { get; set; }
        public DateTime? ReviewedAt { get; set; }
        public string? ReviewedBy { get; set; }
        public DateTime SubmittedAt { get; set; }
    }
}