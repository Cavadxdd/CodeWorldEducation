using CodeWorldEducation.Application.Common.Applications;

namespace CodeWorldEducation.Application.Features.Applications.Queries.GetAll
{
    public class GetAllApplicationsQueryResponse
    {
        public List<GetApplicationDto> Applications { get; set; } = new();
    }
}