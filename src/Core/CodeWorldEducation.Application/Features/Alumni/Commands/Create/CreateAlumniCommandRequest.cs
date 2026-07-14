using CodeWorldEducation.Application.Common.Alumni;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeWorldEducation.Application.Features.Alumni.Commands.Create
{
    public class CreateAlumniCommandRequest : IRequest<CreateAlumniCommandResponse>
    {
        public CreateAlumniDto Dto { get; set; }
    }
}
