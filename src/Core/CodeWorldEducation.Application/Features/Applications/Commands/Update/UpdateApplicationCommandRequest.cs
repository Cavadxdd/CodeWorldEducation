using CodeWorldEducation.Application.Common.Applications;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeWorldEducation.Application.Features.Applications.Commands.Update
{
    public class UpdateApplicationCommandRequest : IRequest<UpdateApplicationCommandResponse>
    {
        public UpdateApplicationDto Dto { get; set; }
    }
}
