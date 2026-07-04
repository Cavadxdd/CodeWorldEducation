using AutoMapper;
using CodeWorldEducation.Application.Abstraction.Services;
using CodeWorldEducation.Application.Common.Course;
using CodeWorldEducation.Application.Common.Courses;
using CodeWorldEducation.Application.UnitOfWorks;
using CodeWorldEducation.Domain.Entities;
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

        public CourseService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<GetCourseListDto>> GetAllAsync()
        {
            var courses = await _unitOfWork.CourseRepository.GetAllAsync();
            return _mapper.Map<List<GetCourseListDto>>(courses);
        }

        public async Task<GetCourseDetailDto> GetByIdAsync(int id)
        {
            if (id <= 0)
                throw new ArgumentException("Id must be greater than 0");

            var course = await _unitOfWork.CourseRepository.GetByIdAsync(id);
            if (course == null)
                throw new Exception($"Course with id {id} not found");

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
                throw new Exception($"Course with slug '{dto.Slug}' already exists");

            var categoryExists = await _unitOfWork.CategoryRepository
                .GetByIdAsync(dto.CategoryId);
            if (categoryExists == null)
                throw new Exception($"Category with id {dto.CategoryId} not found");

            var course = _mapper.Map<Course>(dto);
            course.CreatedAt = DateTime.UtcNow;
            course.UpdatedAt = DateTime.UtcNow;

            await _unitOfWork.CourseRepository.AddAsync(course);
            await _unitOfWork.SaveChangesAsync();

            return _mapper.Map<GetCourseListDto>(course);
        }

        public async Task<GetCourseListDto> UpdateAsync(UpdateCourseDto dto)
        {
            if (dto.Id <= 0)
                throw new ArgumentException("Id must be greater than 0");

            if (string.IsNullOrWhiteSpace(dto.Name))
                throw new ArgumentException("Course name cannot be empty");

            if (string.IsNullOrWhiteSpace(dto.Slug))
                throw new ArgumentException("Course slug cannot be empty");

            var course = await _unitOfWork.CourseRepository.GetByIdAsync(dto.Id);
            if (course == null)
                throw new Exception($"Course with id {dto.Id} not found");

            var slugExists = await _unitOfWork.CourseRepository
                .GetAsync(c => c.Slug == dto.Slug && c.Id != dto.Id);
            if (slugExists != null)
                throw new Exception($"Course with slug '{dto.Slug}' already exists");

            var categoryExists = await _unitOfWork.CategoryRepository
                .GetByIdAsync(dto.CategoryId);
            if (categoryExists == null)
                throw new Exception($"Category with id {dto.CategoryId} not found");

            _mapper.Map(dto, course);
            course.UpdatedAt = DateTime.UtcNow;

            _unitOfWork.CourseRepository.Update(course);
            await _unitOfWork.SaveChangesAsync();

            return _mapper.Map<GetCourseListDto>(course);
        }

        public async Task DeleteAsync(int id)
        {
            if (id <= 0)
                throw new ArgumentException("Id must be greater than 0");

            var course = await _unitOfWork.CourseRepository.GetByIdAsync(id);
            if (course == null)
                throw new Exception($"Course with id {id} not found");

            _unitOfWork.CourseRepository.Delete(course);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
