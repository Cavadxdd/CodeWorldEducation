using CodeWorldEducation.Application.Common.Application;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeWorldEducation.Application.Features.Applications.Commands.Create
{
    public class CreateApplicationCommandRequest : IRequest<CreateApplicationCommandResponse>
    {
        public CreateApplicationDto Dto { get; set; }
    }
}
