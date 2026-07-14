using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeWorldEducation.Application.Features.Alumni.Commands.Delete
{
    public class DeleteAlumniCommandRequest : IRequest<DeleteAlumniCommandResponse>
    {
        public int Id { get; set; }
    }
}
