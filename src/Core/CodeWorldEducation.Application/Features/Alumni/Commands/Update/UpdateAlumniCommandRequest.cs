using CodeWorldEducation.Application.Common.Alumni;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeWorldEducation.Application.Features.Alumni.Commands.Update
{
    public class UpdateAlumniCommandRequest : IRequest<UpdateAlumniCommandResponse>
    {
        public UpdateAlumniDto Dto { get; set; }
    }
}
