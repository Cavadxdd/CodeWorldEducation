using CodeWorldEducation.Application.Abstraction.Services;
using MediatR;

namespace CodeWorldEducation.Application.Features.Alumni.Queries.GetFeaturedAlumni
{
    public class GetFeaturedAlumniQueryHandler
        : IRequestHandler<GetFeaturedAlumniQueryRequest, GetFeaturedAlumniQueryResponse>
    {
        private readonly IAlumniService _alumniService;

        public GetFeaturedAlumniQueryHandler(IAlumniService alumniService)
        {
            _alumniService = alumniService;
        }

        public async Task<GetFeaturedAlumniQueryResponse> Handle(
            GetFeaturedAlumniQueryRequest request,
            CancellationToken cancellationToken)
        {
            var result = await _alumniService.GetFeaturedAsync();
            return new GetFeaturedAlumniQueryResponse { Alumni = result };
        }
    }
}
