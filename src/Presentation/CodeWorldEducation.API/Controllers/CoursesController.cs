using CodeWorldEducation.Application.Common.Course;
using CodeWorldEducation.Application.Features.Courses.Commands.Create;
using CodeWorldEducation.Application.Features.Courses.Commands.Delete;
using CodeWorldEducation.Application.Features.Courses.Commands.Update;
using CodeWorldEducation.Application.Features.Courses.Queries.GetAllCourses;
using CodeWorldEducation.Application.Features.Courses.Queries.GetCourseById;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CodeWorldEducation.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CoursesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var response = await _mediator.Send(new GetAllCoursesQueryRequest());
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var response = await _mediator.Send(new GetCourseByIdQueryRequest { Id = id });
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateCourseDto dto)
        {
            var response = await _mediator.Send(new CreateCourseCommandRequest { Dto = dto });
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateCourseDto dto)
        {
            var response = await _mediator.Send(new UpdateCourseCommandRequest { Dto = dto });
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _mediator.Send(new DeleteCourseCommandRequest { Id = id });
            return Ok(response);
        }
    }
}
