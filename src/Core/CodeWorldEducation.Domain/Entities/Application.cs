using CodeWorldEducation.Domain.Entities.Common;
using CodeWorldEducation.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeWorldEducation.Domain.Entities
{
    public class Application : BaseEntity
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
        public string? CvFilePath { get; set; }
        public string? CvOriginalFileName { get; set; }
        public ApplicationStatus Status { get; set; }
        public string? WhatsAppMessage { get; set; }
        public string? WhatsAppRedirectUrl { get; set; }
        public DateTime SubmittedAt { get; set; }
        public string? IpAddress { get; set; }

        public Course? Course { get; set; }
    }
}
