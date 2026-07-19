using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeWorldEducation.Application.Features.Mentors.Commands.Delete
{
    public class DeleteMentorCommandRequest : IRequest<DeleteMentorCommandResponse>
    {
        public int Id { get; set; }
    }
}
