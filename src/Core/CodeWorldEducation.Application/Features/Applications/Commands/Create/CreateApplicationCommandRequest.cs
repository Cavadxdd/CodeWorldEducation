using CodeWorldEducation.Application.Common.Applications;
using MediatR;

namespace CodeWorldEducation.Application.Features.Applications.Commands.Create
{
    public class CreateApplicationCommandRequest : IRequest<CreateApplicationCommandResponse>
    {
        public CreateApplicationDto Dto { get; set; } = null!;
    }
}