using CodeWorldEducation.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace CodeWorldEducation.Application.Features.Roles.Queries.GetAllRoles;

public class GetAllRolesQueryHandler : IRequestHandler<GetAllRolesQueryRequest, List<GetAllRolesQueryResponse>>
{
    private readonly RoleManager<AppRole> _roleManager;

    public GetAllRolesQueryHandler(RoleManager<AppRole> roleManager)
    {
        _roleManager = roleManager;
    }

    public async Task<List<GetAllRolesQueryResponse>> Handle(
        GetAllRolesQueryRequest request,
        CancellationToken cancellationToken)
    {
        var roles = await _roleManager.Roles.ToListAsync(cancellationToken);

        return roles.Select(r => new GetAllRolesQueryResponse
        {
            Id = r.Id.ToString(),
            Name = r.Name!
        }).ToList();
    }
}