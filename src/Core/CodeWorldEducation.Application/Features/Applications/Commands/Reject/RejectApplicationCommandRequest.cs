using MediatR;

namespace CodeWorldEducation.Application.Features.Applications.Commands.Reject
{
    public class RejectApplicationCommandRequest : IRequest<RejectApplicationCommandResponse>
    {
        public int Id { get; set; }
        public string ReviewedBy { get; set; } = null!;
    }
}