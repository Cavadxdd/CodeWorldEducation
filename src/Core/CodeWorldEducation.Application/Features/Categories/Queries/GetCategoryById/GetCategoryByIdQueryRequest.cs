using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeWorldEducation.Application.Features.Categories.Queries.GetCategoryById
{
    public class GetCategoryByIdQueryRequest : IRequest<GetCategoryByIdQueryResponse>
    {
        public int Id { get; set; }
    }
}
