using AutoMapper;
using CodeWorldEducation.Application.Abstraction.Services;
using CodeWorldEducation.Application.Common.Alumni;
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
    public class AlumniService : IAlumniService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<AlumniService> _logger;

        public AlumniService(IUnitOfWork unitOfWork, IMapper mapper, ILogger<AlumniService> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<List<GetAlumniDetailDto>> GetAllAsync()
        {
            var alumni = await _unitOfWork.AlumniRepository.GetAllAsync();
            _logger.LogInformation(
           "All alumni retrieved. Count: {Count}",
           alumni.Count);
            return _mapper.Map<List<GetAlumniDetailDto>>(alumni);
        }

        public async Task<GetAlumniDetailDto> GetByIdAsync(int id)
        {
            if (id <= 0)
                throw new ArgumentException("Id must be greater than 0");

            var alumni = await _unitOfWork.AlumniRepository.GetByIdAsync(id);
            if (alumni == null)
                throw new KeyNotFoundException($"Alumni with id {id} not found");

            _logger.LogInformation(
            "Alumni retrieved. Id: {Id} | FullName: {FullName}",
            alumni.Id,
            alumni.FullName);

            return _mapper.Map<GetAlumniDetailDto>(alumni);
        }

        public async Task<List<GetAlumniDetailDto>> GetFeaturedAsync()
        {
            var alumni = await _unitOfWork.AlumniRepository.GetActiveAsync();

            _logger.LogInformation(
            "Featured alumni retrieved. Count: {Count} | Time: {Time}",
            alumni.Count,
            DateTime.UtcNow);


            return _mapper.Map<List<GetAlumniDetailDto>>(alumni);
        }

        public async Task<GetAlumniDetailDto> GetDetailAsync(int id)
        {
            if (id <= 0)
                throw new ArgumentException("Id must be greater than 0");

            var alumni = await _unitOfWork.AlumniRepository.GetDetailAsync(id);
            if (alumni == null)
                throw new KeyNotFoundException($"Alumni with id {id} not found");

            _logger.LogInformation(
            "Alumni detail retrieved. Id: {Id} | FullName: {FullName} | Time: {Time}",
            alumni.Id,
            alumni.FullName,
            DateTime.UtcNow);

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

            _logger.LogInformation(
           "Alumni created. Id: {Id} | FullName: {FullName} | " +
           "AlumniType: {AlumniType} | CreatedAt: {CreatedAt}",
           alumni.Id,
           alumni.FullName,
           alumni.AlumniType,
           alumni.CreatedAt);

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

            _logger.LogInformation(
           "Alumni updated. Id: {Id} | FullName: {FullName} | UpdatedAt: {UpdatedAt}",
           alumni.Id,
           alumni.FullName,
           alumni.UpdatedAt);

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

            _logger.LogWarning(
           "Alumni deleted. Id: {Id} | FullName: {FullName} | " +
           "AlumniType: {AlumniType} | DeletedAt: {DeletedAt}",
           alumni.Id,
           alumni.FullName,
           alumni.AlumniType,
           DateTime.UtcNow);
        }
    }
}
