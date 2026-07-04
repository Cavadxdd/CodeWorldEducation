using CodeWorldEducation.Application.Abstraction.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeWorldEducation.Application.Features.Categories.Commands.Create
{
    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommandRequest,CreateCategoryCommandResponse>
    {
        private readonly ICategoryService _categoryService;

        public CreateCategoryCommandHandler(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public async Task<CreateCategoryCommandResponse> Handle(CreateCategoryCommandRequest request,CancellationToken cancellationToken)
        {
            var result = await _categoryService.CreateAsync(request.CreateCategoryDto);
            return new CreateCategoryCommandResponse { GetCategoryDto = result };
        }
    }
}
