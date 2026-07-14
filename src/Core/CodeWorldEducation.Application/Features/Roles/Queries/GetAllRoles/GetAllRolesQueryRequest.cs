using MediatR;

namespace CodeWorldEducation.Application.Features.Roles.Queries.GetAllRoles;

public class GetAllRolesQueryRequest : IRequest<List<GetAllRolesQueryResponse>>
{
}