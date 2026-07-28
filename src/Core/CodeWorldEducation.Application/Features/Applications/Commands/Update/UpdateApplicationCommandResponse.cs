using CodeWorldEducation.Application.Common.Applications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeWorldEducation.Application.Features.Applications.Commands.Update
{
    public class UpdateApplicationCommandResponse
    {
        public bool Success { get; set; }
        public string Message { get; set; } = null!;
        public GetApplicationDto? Application { get; set; }
    }
}
