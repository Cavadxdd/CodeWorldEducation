using CodeWorldEducation.Application.Abstraction.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeWorldEducation.Application.Features.Categories.Queries.GetCategoryById
{
    public class GetCategoryByIdQueryHandler : IRequestHandler<GetCategoryByIdQueryRequest, GetCategoryByIdQueryResponse>
    {
        private readonly ICategoryService _categoryService;

        public GetCategoryByIdQueryHandler(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public async Task<GetCategoryByIdQueryResponse> Handle(
            GetCategoryByIdQueryRequest request,
            CancellationToken cancellationToken)
        {
            var result = await _categoryService.GetByIdAsync(request.Id);
            return new GetCategoryByIdQueryResponse { Category = result };
        }
    }
}
