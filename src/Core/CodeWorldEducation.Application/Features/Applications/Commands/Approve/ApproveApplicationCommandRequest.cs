using MediatR;

namespace CodeWorldEducation.Application.Features.Applications.Commands.Approve
{
    public class ApproveApplicationCommandRequest : IRequest<ApproveApplicationCommandResponse>
    {
        public int Id { get; set; }
        public string ReviewedBy { get; set; } = null!;
    }
}