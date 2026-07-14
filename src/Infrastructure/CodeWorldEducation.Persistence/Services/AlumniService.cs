using AutoMapper;
using CodeWorldEducation.Application.Abstraction.Services;
using CodeWorldEducation.Application.Common.Alumni;
using CodeWorldEducation.Application.UnitOfWorks;
using CodeWorldEducation.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeWorldEducation.Persistence.Services
{
    public class AlumniService : IAlumniService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public AlumniService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<GetAlumniDetailDto>> GetAllAsync()
        {
            var alumni = await _unitOfWork.AlumniRepository.GetAllAsync();
            return _mapper.Map<List<GetAlumniDetailDto>>(alumni);
        }

        public async Task<GetAlumniDetailDto> GetByIdAsync(int id)
        {
            if (id <= 0)
                throw new ArgumentException("Id must be greater than 0");

            var alumni = await _unitOfWork.AlumniRepository.GetByIdAsync(id);
            if (alumni == null)
                throw new KeyNotFoundException($"Alumni with id {id} not found");

            return _mapper.Map<GetAlumniDetailDto>(alumni);
        }

        public async Task<List<GetAlumniDetailDto>> GetFeaturedAsync()
        {
            var alumni = await _unitOfWork.AlumniRepository.GetActiveAsync();

            return _mapper.Map<List<GetAlumniDetailDto>>(alumni);
        }

        public async Task<GetAlumniDetailDto> GetDetailAsync(int id)
        {
            if (id <= 0)
                throw new ArgumentException("Id must be greater than 0");

            var alumni = await _unitOfWork.AlumniRepository.GetDetailAsync(id);
            if (alumni == null)
                throw new KeyNotFoundException($"Alumni with id {id} not found");

            return _mapper.Map<GetAlumniDetailDto>(alumni);
        }

        public async Task<GetAlumniDetailDto> CreateAsync(CreateAlumniDto dto)
        {
            if (string.IsNullOrWhiteSpace(dto.FullName))
                throw new ArgumentException("Full name cannot be empty");

            if (string.IsNullOrWhiteSpace(dto.CompletedCourse))
                throw new ArgumentException("Completed course cannot be empty");

            var alumni = _mapper.Map<Alumni>(dto);
            alumni.CreatedAt = DateTime.UtcNow;
            alumni.UpdatedAt = DateTime.UtcNow;
            alumni.IsActive = true;

            await _unitOfWork.AlumniRepository.AddAsync(alumni);
            await _unitOfWork.SaveChangesAsync();

            return _mapper.Map<GetAlumniDetailDto>(alumni);
        }

        public async Task<GetAlumniDetailDto> UpdateAsync(int id,UpdateAlumniDto dto)
        {
            if (id <= 0)
                throw new ArgumentException("Id must be greater than 0");

            if (string.IsNullOrWhiteSpace(dto.FullName))
                throw new ArgumentException("Full name cannot be empty");

            if (string.IsNullOrWhiteSpace(dto.CompletedCourse))
                throw new ArgumentException("Completed course cannot be empty");

            var alumni = await _unitOfWork.AlumniRepository.GetByIdAsync(id);
            if (alumni == null)
                throw new KeyNotFoundException($"Alumni with id {id} not found");

            _mapper.Map(dto, alumni);
            alumni.UpdatedAt = DateTime.UtcNow;

            _unitOfWork.AlumniRepository.Update(alumni);
            await _unitOfWork.SaveChangesAsync();

            return _mapper.Map<GetAlumniDetailDto>(alumni);
        }

        public async Task DeleteAsync(int id)
        {
            if (id <= 0)
                throw new ArgumentException("Id must be greater than 0");

            var alumni = await _unitOfWork.AlumniRepository.GetByIdAsync(id);
            if (alumni == null)
                throw new KeyNotFoundException($"Alumni with id {id} not found");

            _unitOfWork.AlumniRepository.Delete(alumni);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
