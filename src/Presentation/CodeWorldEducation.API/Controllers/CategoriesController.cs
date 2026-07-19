using CodeWorldEducation.Application.Common.Category;
using CodeWorldEducation.Application.Features.Categories.Commands.Create;
using CodeWorldEducation.Application.Features.Categories.Commands.Delete;
using CodeWorldEducation.Application.Features.Categories.Commands.Update;
using CodeWorldEducation.Application.Features.Categories.Queries.GetCategoryById;
using CodeWorldEducation.Application.Features.Categories.Queries.GetCategoryList;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CodeWorldEducation.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CategoriesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var response = await _mediator.Send(new GetAllCategoriesQueryRequest());
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var response = await _mediator.Send(new GetCategoryByIdQueryRequest { Id = id });
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateCategoryDto dto)
        {
            var response = await _mediator.Send(new CreateCategoryCommandRequest { CreateCategoryDto = dto });
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateCategoryDto dto)
        {
            var response = await _mediator.Send(new UpdateCategoryCommandRequest { Dto = dto });
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _mediator.Send(new DeleteCategoryCommandRequest { Id = id });
            return Ok(response);
        }
    }
}
