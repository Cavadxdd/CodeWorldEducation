using CodeWorldEducation.Application.Abstraction.Services;
using MediatR;

namespace CodeWorldEducation.Application.Features.Alumni.Queries.GetAllAlumni
{
    public class GetAllAlumniQueryHandler
        : IRequestHandler<GetAllAlumniQueryRequest, GetAllAlumniQueryResponse>
    {
        private readonly IAlumniService _alumniService;

        public GetAllAlumniQueryHandler(IAlumniService alumniService)
        {
            _alumniService = alumniService;
        }

        public async Task<GetAllAlumniQueryResponse> Handle(
            GetAllAlumniQueryRequest request,
            CancellationToken cancellationToken)
        {
            var result = await _alumniService.GetAllAsync();
            return new GetAllAlumniQueryResponse { Alumni = result };
        }
    }
}
