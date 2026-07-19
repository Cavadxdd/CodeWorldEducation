using CodeWorldEducation.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeWorldEducation.Application.Features.Roles.Commands.AssignRole
{
	public class AssignRoleCommandHandler : IRequestHandler<AssignRoleCommandRequest, AssignRoleCommandResponse>
	{
		private readonly UserManager<AppUser> _userManager;
		private readonly RoleManager<AppRole> _roleManager;

		public AssignRoleCommandHandler(UserManager<AppUser> userManager, RoleManager<AppRole> roleManager)
		{
			_userManager = userManager;
			_roleManager = roleManager;
		}

		public async Task<AssignRoleCommandResponse> Handle(AssignRoleCommandRequest request, CancellationToken cancellationToken)
		{
			var user = await _userManager.FindByIdAsync(request.UserId);
			if (user == null)
			{
				return new AssignRoleCommandResponse { Succeeded = false, Message = "User tapılmadı." };
			}

			var roleExists = await _roleManager.RoleExistsAsync(request.RoleName);
			if (!roleExists)
			{
				return new AssignRoleCommandResponse { Succeeded = false, Message = "Role mövcud deyil." };
			}

			var isInRole = await _userManager.IsInRoleAsync(user, request.RoleName);
			if (isInRole)
			{
				return new AssignRoleCommandResponse { Succeeded = false, Message = "User artıq bu rola sahibdir." };
			}

			var result = await _userManager.AddToRoleAsync(user, request.RoleName);
			if (result.Succeeded)
			{
				return new AssignRoleCommandResponse { Succeeded = true, Message = "Role assigned successfully." };
			}

			return new AssignRoleCommandResponse { Succeeded = false, Message = "Rolu təyin edərkən xəta baş verdi." };
		}
	}
}
