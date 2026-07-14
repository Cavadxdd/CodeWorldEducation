using CodeWorldEducation.Application.Abstraction.Services;
using MediatR;

namespace CodeWorldEducation.Application.Features.Alumni.Commands.Update
{
    public class UpdateAlumniCommandHandler
        : IRequestHandler<UpdateAlumniCommandRequest, UpdateAlumniCommandResponse>
    {
        private readonly IAlumniService _alumniService;

        public UpdateAlumniCommandHandler(IAlumniService alumniService)
        {
            _alumniService = alumniService;
        }

        public async Task<UpdateAlumniCommandResponse> Handle(
            UpdateAlumniCommandRequest request,
            CancellationToken cancellationToken)
        {
            var result = await _alumniService.UpdateAsync(request.Id,request.Dto);
            return new UpdateAlumniCommandResponse { Alumni = result };
        }
    }
}
