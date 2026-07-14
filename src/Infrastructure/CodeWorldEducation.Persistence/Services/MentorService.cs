using AutoMapper;
using CodeWorldEducation.Application.Abstraction.Services;
using CodeWorldEducation.Application.Common.Courses;
using CodeWorldEducation.Application.Common.Mentor;
using CodeWorldEducation.Application.Common.Mentors;
using CodeWorldEducation.Application.UnitOfWorks;
using CodeWorldEducation.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeWorldEducation.Persistence.Services
{
    public class MentorService : IMentorService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public MentorService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<GetMentorDto>> GetAllAsync()
        {
            var mentors = await _unitOfWork.MentorRepository.GetActiveAsync();
            return _mapper.Map<List<GetMentorDto>>(mentors);
        }

        public async Task<GetMentorDto> GetByIdAsync(int id)
        {
            if (id <= 0)
                throw new ArgumentException("Id must be greater than 0");

            var mentor = await _unitOfWork.MentorRepository.GetByIdAsync(id);
            if (mentor == null)
                throw new KeyNotFoundException($"Mentor with id {id} not found");

            return _mapper.Map<GetMentorDto>(mentor);
        }

        public async Task<List<GetCourseListDto>> GetMentorCoursesAsync(int mentorId)
        {
            if (mentorId <= 0)
                throw new ArgumentException("MentorId must be greater than 0");

            var mentor = await _unitOfWork.MentorRepository.GetWithCoursesAsync(mentorId);
            if (mentor == null)
                throw new KeyNotFoundException($"Mentor with id {mentorId} not found");

            var courses = mentor.MentorCourses.Select(mc => mc.Course).ToList();
            return _mapper.Map<List<GetCourseListDto>>(courses);
        }

        public async Task<GetMentorDetailDto> GetDetailAsync(int id)
        {
            if (id <= 0)
                throw new ArgumentException("Id must be greater than 0");

            var mentor = await _unitOfWork.MentorRepository.GetByIdAsync(id);
            if (mentor == null)
                throw new KeyNotFoundException($"Mentor with id {id} not found");

            return _mapper.Map<GetMentorDetailDto>(mentor);
        }

        public async Task<GetMentorDto> CreateAsync(CreateMentorDto dto)
        {
            if (string.IsNullOrWhiteSpace(dto.FullName))
                throw new ArgumentException("Full name cannot be empty");

            if (string.IsNullOrWhiteSpace(dto.Position))
                throw new ArgumentException("Position cannot be empty");

            if (string.IsNullOrWhiteSpace(dto.PhotoUrl))
                throw new ArgumentException("Photo URL cannot be empty");

            if (dto.Technologies == null || dto.Technologies.Count == 0)
                throw new ArgumentException("At least one technology must be specified");

            var mentor = _mapper.Map<Mentor>(dto);
            mentor.CreatedAt = DateTime.UtcNow;
            mentor.UpdatedAt = DateTime.UtcNow;
            mentor.IsActive = true;

            await _unitOfWork.MentorRepository.AddAsync(mentor);
            await _unitOfWork.SaveChangesAsync();

            return _mapper.Map<GetMentorDto>(mentor);
        }

        public async Task<GetMentorDto> UpdateAsync(int id,UpdateMentorDto dto)
        {
            if (id <= 0)
                throw new ArgumentException("Id must be greater than 0");

            if (string.IsNullOrWhiteSpace(dto.FullName))
                throw new ArgumentException("Full name cannot be empty");

            if (string.IsNullOrWhiteSpace(dto.Position))
                throw new ArgumentException("Position cannot be empty");

            if (dto.Technologies == null || dto.Technologies.Count == 0)
                throw new ArgumentException("At least one technology must be specified");

            var mentor = await _unitOfWork.MentorRepository.GetByIdAsync(id);
            if (mentor == null)
                throw new KeyNotFoundException($"Mentor with id {id} not found");

            _mapper.Map(dto, mentor);
            mentor.UpdatedAt = DateTime.UtcNow;

            _unitOfWork.MentorRepository.Update(mentor);
            await _unitOfWork.SaveChangesAsync();

            return _mapper.Map<GetMentorDto>(mentor);
        }

        public async Task DeleteAsync(int id)
        {
            if (id <= 0)
                throw new ArgumentException("Id must be greater than 0");

            var mentor = await _unitOfWork.MentorRepository.GetByIdAsync(id);
            if (mentor == null)
                throw new KeyNotFoundException($"Mentor with id {id} not found");

            _unitOfWork.MentorRepository.Delete(mentor);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
