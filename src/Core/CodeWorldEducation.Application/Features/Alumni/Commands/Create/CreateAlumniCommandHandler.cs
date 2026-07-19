using CodeWorldEducation.Application.Abstraction.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeWorldEducation.Application.Features.Alumni.Commands.Create
{
    public class CreateAlumniCommandHandler
    : IRequestHandler<CreateAlumniCommandRequest, CreateAlumniCommandResponse>
    {
        private readonly IAlumniService _alumniService;

        public CreateAlumniCommandHandler(IAlumniService alumniService)
        {
            _alumniService = alumniService;
        }

        public async Task<CreateAlumniCommandResponse> Handle(
            CreateAlumniCommandRequest request,
            CancellationToken cancellationToken)
        {
            var result = await _alumniService.CreateAsync(request.Dto);
            return new CreateAlumniCommandResponse { Alumni = result };
        }
    }
}
