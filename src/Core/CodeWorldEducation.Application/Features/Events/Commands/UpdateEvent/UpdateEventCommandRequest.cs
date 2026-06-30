using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MediatR;

namespace CodeWorldEducation.Application.Features.Events.Commands.UpdateEvent;

public class UpdateEventCommandRequest : IRequest<UpdateEventCommandResponse>
{
    public int Id { get; set; }
    public string Title { get; set; } = null!;
    public string Description { get; set; } = null!;
    public DateTime EventDate { get; set; }
}
