using CodeWorldEducation.Application.Common.Mentor;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeWorldEducation.Application.Features.Mentors.Commands.Update
{
    public class UpdateMentorCommandRequest : IRequest<UpdateMentorCommandResponse>
    {
        public UpdateMentorDto Dto { get; set; }
    }

}
