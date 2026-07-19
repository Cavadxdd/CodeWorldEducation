using AutoMapper;
using CodeWorldEducation.Application.Abstraction.Services;
using CodeWorldEducation.Application.Common.Categories;
using CodeWorldEducation.Application.Common.Category;
using CodeWorldEducation.Application.UnitOfWorks;
using CodeWorldEducation.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeWorldEducation.Persistence.Implementations
{
    public class CategoryService : ICategoryService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CategoryService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<GetCategoryDto>> GetAllAsync()
        {
            var categories = await _unitOfWork.CategoryRepository.GetAllAsync();
            return _mapper.Map<List<GetCategoryDto>>(categories);
        }

        public async Task<GetCategoryDto> GetByIdAsync(int id)
        {
            if (id <= 0)
                throw new ArgumentException("Id must be greater than 0");

            var category = await _unitOfWork.CategoryRepository.GetByIdAsync(id);
            if (category == null)
                throw new Exception($"Category with id {id} not found");

            return _mapper.Map<GetCategoryDto>(category);
        }

        public async Task<GetCategoryDto> CreateAsync(CreateCategoryDto dto)
        {
            if (string.IsNullOrWhiteSpace(dto.Name))
                throw new ArgumentException("Category name cannot be empty");

            if (string.IsNullOrWhiteSpace(dto.Slug))
                throw new ArgumentException("Category slug cannot be empty");

            var existingCategory = await _unitOfWork.CategoryRepository
                .GetAsync(c => c.Slug == dto.Slug);
            if (existingCategory != null)
                throw new Exception($"Category with slug '{dto.Slug}' already exists");

            var category = _mapper.Map<Category>(dto);
            category.CreatedAt = DateTime.UtcNow;
            category.UpdatedAt = DateTime.UtcNow;

            await _unitOfWork.CategoryRepository.AddAsync(category);
            await _unitOfWork.SaveChangesAsync();

            return _mapper.Map<GetCategoryDto>(category);
        }

        public async Task<GetCategoryDto> UpdateAsync(UpdateCategoryDto dto)
        {
            if (dto.Id <= 0)
                throw new ArgumentException("Id must be greater than 0");

            if (string.IsNullOrWhiteSpace(dto.Name))
                throw new ArgumentException("Category name cannot be empty");

            if (string.IsNullOrWhiteSpace(dto.Slug))
                throw new ArgumentException("Category slug cannot be empty");

            var category = await _unitOfWork.CategoryRepository.GetByIdAsync(dto.Id);
            if (category == null)
                throw new Exception($"Category with id {dto.Id} not found");

            var slugExists = await _unitOfWork.CategoryRepository
                .GetAsync(c => c.Slug == dto.Slug && c.Id != dto.Id);
            if (slugExists != null)
                throw new Exception($"Category with slug '{dto.Slug}' already exists");

            _mapper.Map(dto, category);
            category.UpdatedAt = DateTime.UtcNow;

            _unitOfWork.CategoryRepository.Update(category);
            await _unitOfWork.SaveChangesAsync();

            return _mapper.Map<GetCategoryDto>(category);
        }

        public async Task DeleteAsync(int id)
        {
            if (id <= 0)
                throw new ArgumentException("Id must be greater than 0");

            var category = await _unitOfWork.CategoryRepository.GetByIdAsync(id);
            if (category == null)
                throw new Exception($"Category with id {id} not found");

            var hasCourses = await _unitOfWork.CategoryRepository
                .GetAsync(c => c.Id == id && c.Courses.Any());
            if (hasCourses != null)
                throw new Exception("Cannot delete category that has courses");

            _unitOfWork.CategoryRepository.Delete(category);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
