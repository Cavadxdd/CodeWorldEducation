using MediatR;

namespace CodeWorldEducation.Application.Features.Courses.Queries.GetCoursesDropdown
{
    public class GetCoursesDropdownQueryRequest : IRequest<List<GetCoursesDropdownQueryResponse>>
    {
    }
}