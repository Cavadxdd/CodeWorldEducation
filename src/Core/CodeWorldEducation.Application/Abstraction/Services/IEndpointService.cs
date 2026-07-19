using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CodeWorldEducation.Application.Abstraction.Services
{
    public interface IEndpointService
    {
        Task RegisterEndpointsAsync(Assembly assembly);
    }
}
