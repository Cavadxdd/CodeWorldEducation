using CodeWorldEducation.Application.Common.Mentor;
using CodeWorldEducation.Application.Common.Mentors;
using CodeWorldEducation.Application.Features.Mentors.Commands.Create;
using CodeWorldEducation.Application.Features.Mentors.Commands.Delete;
using CodeWorldEducation.Application.Features.Mentors.Commands.Update;
using CodeWorldEducation.Application.Features.Mentors.Queries.GetAllMentors;
using CodeWorldEducation.Application.Features.Mentors.Queries.GetMentorCourses;
using CodeWorldEducation.Application.Features.Mentors.Queries.GetMentorDetail;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CodeWorldEducation.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MentorsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public MentorsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var response = await _mediator.Send(new GetAllMentorsQueryRequest());
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var response = await _mediator.Send(
                new GetMentorDetailQueryRequest { Id = id });
            return Ok(response);
        }

        [HttpGet("{mentorId}/courses")]
        public async Task<IActionResult> GetCourses(int mentorId)
        {
            var response = await _mediator.Send(
                new GetMentorCoursesQueryRequest { MentorId = mentorId });
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateMentorDto dto)
        {
            var response = await _mediator.Send(
                new CreateMentorCommandRequest { Dto = dto });
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateMentorDto dto)
        {
            var response = await _mediator.Send(
                new UpdateMentorCommandRequest { Dto = dto });
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _mediator.Send(
                new DeleteMentorCommandRequest { Id = id });
            return Ok(response);
        }
    }
}
