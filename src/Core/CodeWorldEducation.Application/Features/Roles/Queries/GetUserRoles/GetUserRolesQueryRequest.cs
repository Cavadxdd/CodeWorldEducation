using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeWorldEducation.Application.Features.Roles.Queries.GetUserRoles
{
	public class GetUserRolesQueryRequest : IRequest<IList<string>>
	{
		public string UserId { get; set; }
	}
}
