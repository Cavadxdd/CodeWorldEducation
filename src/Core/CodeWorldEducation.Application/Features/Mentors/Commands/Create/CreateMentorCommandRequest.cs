using CodeWorldEducation.Application.Common.Mentors;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeWorldEducation.Application.Features.Mentors.Commands.Create
{
    public class CreateMentorCommandRequest : IRequest<CreateMentorCommandResponse>
    {
        public CreateMentorDto Dto { get; set; }
    }
}
