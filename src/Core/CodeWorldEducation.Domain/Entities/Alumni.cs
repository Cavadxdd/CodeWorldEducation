using CodeWorldEducation.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeWorldEducation.Domain.Entities
{
    public class Alumni : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhotoUrl { get; set; }
        public string TestimonialText { get; set; }
        public string CurrentCompany { get; set; }
        public string PortfolioUrl { get; set; }
        public int CourseId { get; set; }
        public Course Course { get; set; }
    }
}
