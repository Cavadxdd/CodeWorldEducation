using CodeWorldEducation.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeWorldEducation.Application.Common.Application
{
    public class CreateApplicationResponseDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CourseName { get; set; }
        public ApplicantType ApplicantType { get; set; }
        public TeachingMode? TeachingMode { get; set; }
        public string WhatsAppUrl { get; set; }
    }
}
