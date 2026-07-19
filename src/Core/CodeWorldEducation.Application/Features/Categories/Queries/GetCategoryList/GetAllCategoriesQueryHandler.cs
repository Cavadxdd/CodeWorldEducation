using CodeWorldEducation.Application.Abstraction.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeWorldEducation.Application.Features.Categories.Queries.GetCategoryList
{
    public class GetAllCategoriesQueryHandler : IRequestHandler<GetAllCategoriesQueryRequest, GetAllCategoriesQueryResponse>
    {
        private readonly ICategoryService _categoryService;

        public GetAllCategoriesQueryHandler(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public async Task<GetAllCategoriesQueryResponse> Handle(
            GetAllCategoriesQueryRequest request,
            CancellationToken cancellationToken)
        {
            var result = await _categoryService.GetAllAsync();
            return new GetAllCategoriesQueryResponse { Categories = result };
        }
    }
}
