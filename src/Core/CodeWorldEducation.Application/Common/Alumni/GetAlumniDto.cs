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
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhotoUrl { get; set; }
        public string CurrentCompany { get; set; }
        public string PortfolioUrl { get; set; }
        public string TestimonialText { get; set; }
        public string CourseName { get; set; }
    }
}
