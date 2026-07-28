using AutoMapper;
using CodeWorldEducation.Application.Abstraction.Services;
using CodeWorldEducation.Application.Common.Applications;
using CodeWorldEducation.Application.Helpers;
using CodeWorldEducation.Application.UnitOfWorks;
using CodeWorldEducation.Domain.Enums;
using Microsoft.Extensions.Logging;

namespace CodeWorldEducation.Persistence.Services
{
    public class ApplicationService : IApplicationService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<ApplicationService> _logger;
        private readonly IFileService _fileService;

        public ApplicationService(IUnitOfWork unitOfWork, IMapper mapper,
            ILogger<ApplicationService> logger, IFileService fileService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
            _fileService = fileService;
        }

        public async Task<List<GetApplicationDto>> GetAllAsync(
            ApplicantType? type = null, ApplicationStatus? status = null)
        {
            var applications = await _unitOfWork.ApplicationRepository.GetAllAsync();

            if (type.HasValue)
                applications = applications.Where(a => a.ApplicantType == type.Value).ToList();

            if (status.HasValue)
                applications = applications.Where(a => a.Status == status.Value).ToList();

            return _mapper.Map<List<GetApplicationDto>>(applications);
        }

        public async Task<GetApplicationDto> GetByIdAsync(int id)
        {
            var application = await _unitOfWork.ApplicationRepository.GetByIdAsync(id);
            if (application == null)
                throw new Exception($"Application with id {id} not found");

            return _mapper.Map<GetApplicationDto>(application);
        }

        public async Task<GetApplicationDto> CreateAsync(CreateApplicationDto dto)
        {
            if (string.IsNullOrWhiteSpace(dto.FullName))
                throw new ArgumentException("FullName cannot be empty");

            if (string.IsNullOrWhiteSpace(dto.PhoneNumber))
                throw new ArgumentException("PhoneNumber cannot be empty");

            if (dto.ApplicantType == ApplicantType.Student && dto.EducationMode == null)
                throw new ArgumentException("EducationMode is required for Student");

            if (dto.ApplicantType == ApplicantType.Internship && dto.CvFile == null)
                throw new ArgumentException("CV is required for Internship");

            var application = _mapper.Map<Domain.Entities.Application>(dto);

            if (dto.CvFile != null)
            {
                var (fileName, filePath) = await _fileService.UploadCvAsync(dto.CvFile);
                application.CvFilePath = filePath;
                application.CvOriginalFileName = fileName;
            }

            application.Status = ApplicationStatus.Pending;
            application.SubmittedAt = DateTime.UtcNow;
            application.CreatedAt = DateTime.UtcNow;
            application.UpdatedAt = DateTime.UtcNow;

            await _unitOfWork.ApplicationRepository.AddAsync(application);
            await _unitOfWork.SaveChangesAsync();

            _logger.LogInformation("Application created. Id: {Id} | Type: {Type}",
                application.Id, application.ApplicantType);

            return _mapper.Map<GetApplicationDto>(application);
        }

        public async Task<GetApplicationDto> ApproveAsync(int id, string reviewedBy)
        {
            var application = await _unitOfWork.ApplicationRepository.GetByIdAsync(id);
            if (application == null)
                throw new Exception($"Application with id {id} not found");

            application.Status = ApplicationStatus.Approved;
            application.ReviewedAt = DateTime.UtcNow;
            application.ReviewedBy = reviewedBy;
            application.UpdatedAt = DateTime.UtcNow;

            _unitOfWork.ApplicationRepository.Update(application);
            await _unitOfWork.SaveChangesAsync();

            _logger.LogInformation("Application approved. Id: {Id} | ReviewedBy: {ReviewedBy}",
                id, reviewedBy);

            return _mapper.Map<GetApplicationDto>(application);
        }

        public async Task<GetApplicationDto> RejectAsync(int id, string reviewedBy)
        {
            var application = await _unitOfWork.ApplicationRepository.GetByIdAsync(id);
            if (application == null)
                throw new Exception($"Application with id {id} not found");

            application.Status = ApplicationStatus.Rejected;
            application.ReviewedAt = DateTime.UtcNow;
            application.ReviewedBy = reviewedBy;
            application.UpdatedAt = DateTime.UtcNow;

            _unitOfWork.ApplicationRepository.Update(application);
            await _unitOfWork.SaveChangesAsync();

            _logger.LogInformation("Application rejected. Id: {Id} | ReviewedBy: {ReviewedBy}",
                id, reviewedBy);

            return _mapper.Map<GetApplicationDto>(application);
        }

        public async Task DeleteAsync(int id)
        {
            var application = await _unitOfWork.ApplicationRepository.GetByIdAsync(id);
            if (application == null)
                throw new Exception($"Application with id {id} not found");

            _unitOfWork.ApplicationRepository.Delete(application);
            await _unitOfWork.SaveChangesAsync();

            _logger.LogWarning("Application deleted. Id: {Id}", id);
        }
    }
}