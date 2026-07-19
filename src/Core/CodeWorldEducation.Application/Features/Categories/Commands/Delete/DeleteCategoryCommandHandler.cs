using CodeWorldEducation.Application.Abstraction.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeWorldEducation.Application.Features.Categories.Commands.Delete
{
    public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommandRequest, DeleteCategoryCommandResponse>
    {
        private readonly ICategoryService _categoryService;

        public DeleteCategoryCommandHandler(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public async Task<DeleteCategoryCommandResponse> Handle(
            DeleteCategoryCommandRequest request,
            CancellationToken cancellationToken)
        {
            await _categoryService.DeleteAsync(request.Id);
            return new DeleteCategoryCommandResponse
            {
                Success = true,
                Message = "Category deleted successfully"
            };
        }
    }
}
