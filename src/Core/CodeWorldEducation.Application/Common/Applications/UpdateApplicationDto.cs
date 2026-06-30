using CodeWorldEducation.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeWorldEducation.Application.Common.Applications
{
    public class UpdateApplicationDto
    {
        public int Id { get; set; }
        public ApplicationStatus Status { get; set; }
        public string? WhatsAppMessage { get; set; }
        public string? WhatsAppRedirectUrl { get; set; }
    }
}
