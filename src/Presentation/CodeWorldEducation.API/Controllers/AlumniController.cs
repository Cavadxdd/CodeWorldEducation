using CodeWorldEducation.Application.Common.Alumni;
using CodeWorldEducation.Application.Features.Alumni.Commands.Create;
using CodeWorldEducation.Application.Features.Alumni.Commands.Delete;
using CodeWorldEducation.Application.Features.Alumni.Commands.Update;
using CodeWorldEducation.Application.Features.Alumni.Queries.GetAllAlumni;
using CodeWorldEducation.Application.Features.Alumni.Queries.GetAlumniDetail;
using CodeWorldEducation.Application.Features.Alumni.Queries.GetFeaturedAlumni;
using CodeWorldEducation.Application.Features.Mentors.Commands.Update;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CodeWorldEducation.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AlumniController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AlumniController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var response = await _mediator.Send(new GetAllAlumniQueryRequest());
            return Ok(response);
        }

        [HttpGet("featured")]
        public async Task<IActionResult> GetFeatured()
        {
            var response = await _mediator.Send(new GetFeaturedAlumniQueryRequest());
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetDetail(int id)
        {
            var response = await _mediator.Send(
                new GetAlumniDetailQueryRequest { Id = id });
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateAlumniDto dto)
        {
            var response = await _mediator.Send(
                new CreateAlumniCommandRequest { Dto = dto });
            return Ok(response);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateAlumniDto dto)
        {
            var response = await _mediator.Send(new UpdateAlumniCommandRequest
            {
                Id = id,
                Dto = dto
            });

            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _mediator.Send(
                new DeleteAlumniCommandRequest { Id = id });
            return Ok(response);
        }
    }
}
