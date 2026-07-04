using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeWorldEducation.Application.Features.Categories.Queries.GetCategoryList
{
    public class GetAllCategoriesQueryRequest : IRequest<GetAllCategoriesQueryResponse>
    {
    }
}
