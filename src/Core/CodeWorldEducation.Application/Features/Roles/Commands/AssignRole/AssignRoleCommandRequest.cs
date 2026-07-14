using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeWorldEducation.Application.Features.Roles.Commands.AssignRole
{
	public class AssignRoleCommandRequest : IRequest<AssignRoleCommandResponse>
	{
		public string UserId { get; set; }
		public string RoleName { get; set; }
	}
}
