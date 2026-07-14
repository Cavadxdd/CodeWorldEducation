using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeWorldEducation.Application.Features.Events.Commands.UpdateEvent;

public class UpdateEventCommandResponse
{
    public bool Success { get; set; }
    public string Message { get; set; } = null!;
}
