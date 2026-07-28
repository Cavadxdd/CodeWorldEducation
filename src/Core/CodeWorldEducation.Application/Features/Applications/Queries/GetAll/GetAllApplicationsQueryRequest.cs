using CodeWorldEducation.Domain.Enums;
using MediatR;

namespace CodeWorldEducation.Application.Features.Applications.Queries.GetAll
{
    public class GetAllApplicationsQueryRequest : IRequest<GetAllApplicationsQueryResponse>
    {
        public ApplicantType? Type { get; set; }
        public ApplicationStatus? Status { get; set; }
    }
}