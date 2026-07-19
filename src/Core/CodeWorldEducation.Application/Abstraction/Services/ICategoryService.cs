using CodeWorldEducation.Application.Common.Categories;
using CodeWorldEducation.Application.Common.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeWorldEducation.Application.Abstraction.Services
{
    public interface ICategoryService
    {
        Task<List<GetCategoryDto>> GetAllAsync();
        Task<GetCategoryDto> GetByIdAsync(int id);
        Task<GetCategoryDto> CreateAsync(CreateCategoryDto dto);
        Task<GetCategoryDto> UpdateAsync(UpdateCategoryDto dto);
        Task DeleteAsync(int id);
    }
}
