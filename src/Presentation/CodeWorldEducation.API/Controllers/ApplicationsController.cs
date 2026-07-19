using CodeWorldEducation.Application.Common.Application;
using CodeWorldEducation.Application.Common.Applications;
using CodeWorldEducation.Application.Features.Applications.Commands.Create;
using CodeWorldEducation.Application.Features.Applications.Commands.Delete;
using CodeWorldEducation.Application.Features.Applications.Commands.Update;
using CodeWorldEducation.Application.Features.Applications.Queries.GetAll;
using CodeWorldEducation.Application.Features.Applications.Queries.GetById;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CodeWorldEducation.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicationsController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IWebHostEnvironment _environment;

        public ApplicationsController(IMediator mediator, IWebHostEnvironment environment)
        {
            _mediator = mediator;
            _environment = environment;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var response = await _mediator.Send(new GetAllApplicationsQueryRequest());
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var response = await _mediator.Send(
                new GetApplicationByIdQueryRequest { Id = id });
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Create(
            [FromForm] CreateApplicationDto dto,
            IFormFile? cvFile)
        {
            if (cvFile != null && cvFile.Length > 0)
            {
                var allowedExtensions = new[] { ".pdf", ".doc", ".docx" };
                var extension = Path.GetExtension(cvFile.FileName).ToLower();

                if (!allowedExtensions.Contains(extension))
                    return BadRequest("CV must be .pdf, .doc or .docx format");

                var uploadsFolder = Path.Combine(_environment.WebRootPath, "uploads", "cv");
                if (!Directory.Exists(uploadsFolder))
                    Directory.CreateDirectory(uploadsFolder);

                var uniqueFileName = $"{Guid.NewGuid()}{extension}";
                var filePath = Path.Combine(uploadsFolder, uniqueFileName);

                using var stream = new FileStream(filePath, FileMode.Create);
                await cvFile.CopyToAsync(stream);

                dto.CvFilePath = $"/uploads/cv/{uniqueFileName}";
                dto.CvOriginalFileName = cvFile.FileName;
            }

            var response = await _mediator.Send(
                new CreateApplicationCommandRequest { Dto = dto });
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateApplicationDto dto)
        {
            var response = await _mediator.Send(
                new UpdateApplicationCommandRequest { Dto = dto });
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _mediator.Send(
                new DeleteApplicationCommandRequest { Id = id });
            return Ok(response);
        }
    }
}
