using AutoMapper;
using CodeWorldEducation.Application.Abstraction.Services;
using CodeWorldEducation.Application.Common.Course;
using CodeWorldEducation.Application.Common.Courses;
using CodeWorldEducation.Application.UnitOfWorks;
using CodeWorldEducation.Domain.Entities;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeWorldEducation.Persistence.Services
{
    public class CourseService : ICourseService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<CourseService> _logger;

        public CourseService(IUnitOfWork unitOfWork, IMapper mapper, ILogger<CourseService> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<List<GetCourseListDto>> GetAllAsync()
        {
            var courses = await _unitOfWork.CourseRepository.GetAllWithCategoryAsync();

            _logger.LogInformation(
                "All courses retrieved. Count: {Count}",
                courses.Count);
            return _mapper.Map<List<GetCourseListDto>>(courses);
        }

        public async Task<GetCourseDetailDto> GetByIdAsync(int id)
        {
            if (id <= 0)
                throw new ArgumentException("Id must be greater than 0");

            var course = await _unitOfWork.CourseRepository.GetDetailWithMentorsAsync(id);

            if (course == null)
                throw new KeyNotFoundException($"Course with id {id} not found");

            _logger.LogInformation(
                "Course retrieved. Id: {Id} | Name: {Name}",
                course.Id,
                course.Name);

            return _mapper.Map<GetCourseDetailDto>(course);
        }

        public async Task<GetCourseListDto> CreateAsync(CreateCourseDto dto)
        {
            if (string.IsNullOrWhiteSpace(dto.Name))
                throw new ArgumentException("Course name cannot be empty");

            if (string.IsNullOrWhiteSpace(dto.Slug))
                throw new ArgumentException("Course slug cannot be empty");

            var slugExists = await _unitOfWork.CourseRepository
                .GetAsync(c => c.Slug == dto.Slug);
            if (slugExists != null)
                throw new InvalidOperationException($"Course with slug '{dto.Slug}' already exists");

            var categoryExists = await _unitOfWork.CategoryRepository
                .GetByIdAsync(dto.CategoryId);
            if (categoryExists == null)
                throw new KeyNotFoundException($"Category with id {dto.CategoryId} not found");

            var course = _mapper.Map<Course>(dto);
            course.CreatedAt = DateTime.UtcNow;
            course.UpdatedAt = DateTime.UtcNow;

            await _unitOfWork.CourseRepository.AddAsync(course);
            await _unitOfWork.SaveChangesAsync();

            _logger.LogInformation(
                "Course created. Id: {Id} | Name: {Name} | CreatedAt: {CreatedAt}",
                course.Id,
                course.Name,
                course.CreatedAt);

            return _mapper.Map<GetCourseListDto>(course);
        }

        public async Task<GetCourseListDto> UpdateAsync(int id, UpdateCourseDto dto)
        {
            if (id <= 0)
                throw new ArgumentException("Id must be greater than 0");

            

            if (string.IsNullOrWhiteSpace(dto.Name))
                throw new ArgumentException("Course name cannot be empty");

            if (string.IsNullOrWhiteSpace(dto.Slug))
                throw new ArgumentException("Course slug cannot be empty");

            var course = await _unitOfWork.CourseRepository.GetByIdAsync(id);
            if (course == null)
                throw new KeyNotFoundException($"Course with id {id} not found");

            var slugExists = await _unitOfWork.CourseRepository
                .GetAsync(c => c.Slug == dto.Slug && c.Id != id);
            if (slugExists != null)
                throw new InvalidOperationException($"Course with slug '{dto.Slug}' already exists");

            var categoryExists = await _unitOfWork.CategoryRepository
                .GetByIdAsync(dto.CategoryId);
            if (categoryExists == null)
                throw new KeyNotFoundException($"Category with id {dto.CategoryId} not found");

            _mapper.Map(dto, course);
            course.UpdatedAt = DateTime.UtcNow;

            _unitOfWork.CourseRepository.Update(course);
            await _unitOfWork.SaveChangesAsync();

            var updatedCourse = await _unitOfWork.CourseRepository.GetWithCategoryByIdAsync(id);

            _logger.LogInformation(
                "Course updated. Id: {Id} | Name: {Name} | UpdatedAt: {UpdatedAt}",
                course.Id,
                course.Name,
                course.UpdatedAt);

            return _mapper.Map<GetCourseListDto>(updatedCourse);
        }

        public async Task DeleteAsync(int id)
        {
            if (id <= 0)
                throw new ArgumentException("Id must be greater than 0");

            var course = await _unitOfWork.CourseRepository.GetByIdAsync(id);
            if (course == null)
                throw new KeyNotFoundException($"Course with id {id} not found");

            _unitOfWork.CourseRepository.Delete(course);
            await _unitOfWork.SaveChangesAsync();

            _logger.LogWarning(
                "Course deleted. Id: {Id} | Name: {Name} | DeletedAt: {DeletedAt}",
                course.Id,
                course.Name,
                DateTime.UtcNow);
        }

        public async Task<List<GetCourseListDto>> GetByCategoryAsync(int categoryId)
        {
            if (categoryId <= 0)
                throw new ArgumentException("CategoryId must be greater than 0");

            var category = await _unitOfWork.CategoryRepository.GetByIdAsync(categoryId);
            if (category == null)
                throw new KeyNotFoundException($"Category with id {categoryId} not found");

            var courses = await _unitOfWork.CourseRepository.GetByCategoryAsync(categoryId);

            _logger.LogInformation(
                "Courses retrieved by category. CategoryId: {CategoryId} | CategoryName: {CategoryName} | Count: {Count} | Time: {Time}",
                categoryId,
                category.Name,
                courses.Count,
                DateTime.UtcNow);

            return _mapper.Map<List<GetCourseListDto>>(courses);
        }

        public async Task<GetCourseDetailDto> GetDetailBySlugAsync(string slug)
        {
            if (string.IsNullOrWhiteSpace(slug))
                throw new ArgumentException("Slug cannot be empty");

            var course = await _unitOfWork.CourseRepository
                .GetBySlugAsync(slug);

            if (course == null)
                throw new KeyNotFoundException($"Course with slug '{slug}' not found");

            _logger.LogInformation(
                "Course detail retrieved by slug. Slug: {Slug} | Id: {Id} | Name: {Name} | Time: {Time}",
                slug,
                course.Id,
                course.Name,
                DateTime.UtcNow);

            return _mapper.Map<GetCourseDetailDto>(course);
        }
    }
}
