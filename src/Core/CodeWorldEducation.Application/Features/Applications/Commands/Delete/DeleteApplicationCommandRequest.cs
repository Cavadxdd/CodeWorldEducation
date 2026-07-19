using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeWorldEducation.Application.Features.Applications.Commands.Delete
{
    public class DeleteApplicationCommandRequest : IRequest<DeleteApplicationCommandResponse>
    {
        public int Id { get; set; }
    }
}
