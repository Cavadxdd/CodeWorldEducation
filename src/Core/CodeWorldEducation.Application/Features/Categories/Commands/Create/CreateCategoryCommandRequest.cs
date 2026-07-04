using CodeWorldEducation.Application.Common.Category;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeWorldEducation.Application.Features.Categories.Commands.Create
{
    public class CreateCategoryCommandRequest : IRequest<CreateCategoryCommandResponse>
    {
        public CreateCategoryDto CreateCategoryDto { get; set; }
    }
}
