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
        public string FullName { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public ApplicantType ApplicantType { get; set; }
        public int CourseId { get; set; }
        public TeachingMode? EducationMode { get; set; }
        public string? BehanceUrl { get; set; }
        public string? DribbbleUrl { get; set; }
        public string? CvFilePath { get; set; }
        public string? CvOriginalFileName { get; set; }
        public string? Note { get; set; }
        public ApplicationStatus Status { get; set; } = ApplicationStatus.Pending;
        public DateTime? ReviewedAt { get; set; }
        public string? ReviewedBy { get; set; }
        public string? WhatsAppMessage { get; set; }
        public string? WhatsAppRedirectUrl { get; set; }
        public DateTime SubmittedAt { get; set; } = DateTime.UtcNow;

        public Course? Course { get; set; }
    }
}