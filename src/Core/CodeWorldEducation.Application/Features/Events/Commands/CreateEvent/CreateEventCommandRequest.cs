using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MediatR;

namespace CodeWorldEducation.Application.Features.Events.Commands.CreateEvent;

public class CreateEventCommandRequest : IRequest<CreateEventCommandResponse>
{
    public string Title { get; set; } = null!;
    public string Description { get; set; } = null!;
    public DateTime EventDate { get; set; }
}
