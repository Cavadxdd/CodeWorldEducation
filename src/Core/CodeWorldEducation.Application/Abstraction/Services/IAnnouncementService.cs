using CodeWorldEducation.Application.Features.Announcements.Commands.CreateAnnouncement;
using CodeWorldEducation.Application.Features.Announcements.Commands.UpdateAnnouncement;
using CodeWorldEducation.Application.Features.Announcements.Commands.DeleteAnnouncement;
using CodeWorldEducation.Domain.Entities;

namespace CodeWorldEducation.Application.Abstraction.Services;

public interface IAnnouncementService
{
    Task<List<Announcement>> GetAllAsync();
    Task<Announcement?> GetByIdAsync(int id);
    Task<CreateAnnouncementCommandResponse> CreateAsync(CreateAnnouncementCommandRequest request);
    Task<UpdateAnnouncementCommandResponse> UpdateAsync(UpdateAnnouncementCommandRequest request);
    Task<DeleteAnnouncementCommandResponse> DeleteAsync(int id);
}