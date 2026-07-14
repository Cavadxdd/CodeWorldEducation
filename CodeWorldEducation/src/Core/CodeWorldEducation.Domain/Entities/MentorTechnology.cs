using CodeWorldEducation.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeWorldEducation.Domain.Entities
{
    public class MentorTechnology : BaseEntity
    {
        public string TechnologyName { get; set; }
        public string LogoUrl { get; set; }
        public int MentorId { get; set; }

        public Mentor Mentor { get; set; }
    }
}
