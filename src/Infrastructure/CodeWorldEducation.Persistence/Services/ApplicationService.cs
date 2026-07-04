using AutoMapper;
using CodeWorldEducation.Application.Abstraction.Services;
using CodeWorldEducation.Application.Common.Application;
using CodeWorldEducation.Application.Common.Applications;
using CodeWorldEducation.Application.Helpers;
using CodeWorldEducation.Application.UnitOfWorks;
using CodeWorldEducation.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeWorldEducation.Persistence.Services
{
    public class ApplicationService : IApplicationService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ApplicationService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<GetApplicationDto>> GetAllAsync()
        {
            var applications = await _unitOfWork.ApplicationRepository.GetAllAsync();
            return _mapper.Map<List<GetApplicationDto>>(applications);
        }

        public async Task<GetApplicationDto> GetByIdAsync(int id)
        {
            if (id <= 0)
                throw new ArgumentException("Id must be greater than 0");

            var application = await _unitOfWork.ApplicationRepository.GetByIdAsync(id);
            if (application == null)
                throw new Exception($"Application with id {id} not found");

            return _mapper.Map<GetApplicationDto>(application);
        }

        public async Task<GetApplicationDto> CreateAsync(CreateApplicationDto dto)
        {
            if (string.IsNullOrWhiteSpace(dto.FirstName))
                throw new ArgumentException("First name cannot be empty");

            if (string.IsNullOrWhiteSpace(dto.LastName))
                throw new ArgumentException("Last name cannot be empty");

            if (string.IsNullOrWhiteSpace(dto.Phone))
                throw new ArgumentException("Phone cannot be empty");

            if (dto.ApplicantType == ApplicantType.Student && dto.CourseId == null)
                throw new ArgumentException("Course must be selected for student applicants");

            if (dto.ApplicantType == ApplicantType.Intern &&
                string.IsNullOrWhiteSpace(dto.Field))
                throw new ArgumentException("Field must be specified for intern applicants");

            if (dto.CourseId.HasValue)
            {
                var course = await _unitOfWork.CourseRepository.GetByIdAsync(dto.CourseId.Value);
                if (course == null)
                    throw new Exception($"Course with id {dto.CourseId} not found");
            }

            var application = _mapper.Map<Domain.Entities.Application>(dto);
            application.SubmittedAt = DateTime.UtcNow;
            application.Status = ApplicationStatus.New;
            application.CreatedAt = DateTime.UtcNow;
            application.UpdatedAt = DateTime.UtcNow;

            application.WhatsAppMessage = WhatsAppHelper.GenerateMessage(dto);
            application.WhatsAppRedirectUrl = WhatsAppHelper.GenerateUrl(application.WhatsAppMessage);

            await _unitOfWork.ApplicationRepository.AddAsync(application);
            await _unitOfWork.SaveChangesAsync();

            return _mapper.Map<GetApplicationDto>(application);
        }

        public async Task<GetApplicationDto> UpdateAsync(UpdateApplicationDto dto)
        {
            if (dto.Id <= 0)
                throw new ArgumentException("Id must be greater than 0");

            var application = await _unitOfWork.ApplicationRepository.GetByIdAsync(dto.Id);
            if (application == null)
                throw new Exception($"Application with id {dto.Id} not found");

            application.Status = dto.Status;
            application.UpdatedAt = DateTime.UtcNow;

            _unitOfWork.ApplicationRepository.Update(application);
            await _unitOfWork.SaveChangesAsync();

            return _mapper.Map<GetApplicationDto>(application);
        }

        public async Task DeleteAsync(int id)
        {
            if (id <= 0)
                throw new ArgumentException("Id must be greater than 0");

            var application = await _unitOfWork.ApplicationRepository.GetByIdAsync(id);
            if (application == null)
                throw new Exception($"Application with id {id} not found");

            _unitOfWork.ApplicationRepository.Delete(application);
            await _unitOfWork.SaveChangesAsync();
        }

    }
}
