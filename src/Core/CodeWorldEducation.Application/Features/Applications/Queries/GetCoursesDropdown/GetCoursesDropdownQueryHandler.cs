using CodeWorldEducation.Application.UnitOfWorks;
using MediatR;

namespace CodeWorldEducation.Application.Features.Courses.Queries.GetCoursesDropdown
{
    public class GetCoursesDropdownQueryHandler
        : IRequestHandler<GetCoursesDropdownQueryRequest, List<GetCoursesDropdownQueryResponse>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetCoursesDropdownQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<GetCoursesDropdownQueryResponse>> Handle(
            GetCoursesDropdownQueryRequest request,
            CancellationToken cancellationToken)
        {
            var courses = await _unitOfWork.CourseRepository.GetAllAsync();
            return courses
                .Where(c => c.IsActive)
                .OrderBy(c => c.SortOrder)
                .Select(c => new GetCoursesDropdownQueryResponse
                {
                    Id = c.Id,
                    Name = c.Name
                })
                .ToList();
        }
    }
}