using CodeWorldEducation.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeWorldEducation.Domain.Entities
{
    public class Endpoint : BaseEntity
    {
        public string Code { get; set; } = null!;
        public string HttpMethod { get; set; } = null!;
        public string Route {  get; set; } = null!;
        public string Definition { get; set; } = null!;
        public string Menu { get; set; } = null!;
        public ICollection<EndpointRole> EndpointRoles { get; set; } = new List<EndpointRole>();
    }
}
