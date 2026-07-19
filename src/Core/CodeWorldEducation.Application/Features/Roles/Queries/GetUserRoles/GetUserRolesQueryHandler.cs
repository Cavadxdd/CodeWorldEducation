using CodeWorldEducation.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeWorldEducation.Application.Features.Roles.Queries.GetUserRoles
{
	public class GetUserRolesQueryHandler : IRequestHandler<GetUserRolesQueryRequest, IList<string>>
	{
		private readonly UserManager<AppUser> _userManager;

		public GetUserRolesQueryHandler(UserManager<AppUser> userManager)
		{
			_userManager = userManager;
		}

		public async Task<IList<string>> Handle(GetUserRolesQueryRequest request, CancellationToken cancellationToken)
		{
			var user = await _userManager.FindByIdAsync(request.UserId);
			if (user == null)
			{
				return new List<string>();
			}

			var roles = await _userManager.GetRolesAsync(user);
			return roles;
		}
	}
}
