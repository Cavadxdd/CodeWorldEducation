using CodeWorldEducation.Application.Abstraction.Services;
using MediatR;

namespace CodeWorldEducation.Application.Features.Alumni.Queries.GetAlumniDetail
{
    public class GetAlumniDetailQueryHandler
        : IRequestHandler<GetAlumniDetailQueryRequest, GetAlumniDetailQueryResponse>
    {
        private readonly IAlumniService _alumniService;

        public GetAlumniDetailQueryHandler(IAlumniService alumniService)
        {
            _alumniService = alumniService;
        }

        public async Task<GetAlumniDetailQueryResponse> Handle(
            GetAlumniDetailQueryRequest request,
            CancellationToken cancellationToken)
        {
            var result = await _alumniService.GetDetailAsync(request.Id);
            return new GetAlumniDetailQueryResponse { Alumni = result };
        }
    }
}
