using CodeWorldEducation.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeWorldEducation.Domain.Entities
{
    public class EndpointRole :BaseEntity
    {
        public int EndpointId { get; set; }
        public Endpoint Endpoint { get; set; } = null!;
        public string RoleName { get; set; } = null!;
    }
}
