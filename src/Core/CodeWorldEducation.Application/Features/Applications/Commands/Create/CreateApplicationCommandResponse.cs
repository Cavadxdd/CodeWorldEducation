using CodeWorldEducation.Application.Common.Applications;

namespace CodeWorldEducation.Application.Features.Applications.Commands.Create
{
    public class CreateApplicationCommandResponse
    {
        public bool Success { get; set; }
        public string Message { get; set; } = null!;
        public GetApplicationDto? Application { get; set; }
    }
}