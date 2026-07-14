using CodeWorldEducation.Application.Abstraction.Services;
using CodeWorldEducation.Application.Features.Announcements.Commands.CreateAnnouncement;
using CodeWorldEducation.Application.Features.Announcements.Commands.UpdateAnnouncement;
using CodeWorldEducation.Application.Features.Announcements.Commands.DeleteAnnouncement;
using CodeWorldEducation.Domain.Entities;

namespace CodeWorldEducation.Infrastructure.Services;

public class AnnouncementService : IAnnouncementService
{
    public async Task<List<Announcement>> GetAllAsync() => throw new NotImplementedException();
    public async Task<Announcement?> GetByIdAsync(int id) => throw new NotImplementedException();
    public async Task<CreateAnnouncementCommandResponse> CreateAsync(CreateAnnouncementCommandRequest request) => throw new NotImplementedException();
    public async Task<UpdateAnnouncementCommandResponse> UpdateAsync(UpdateAnnouncementCommandRequest request) => throw new NotImplementedException();
    public async Task<DeleteAnnouncementCommandResponse> DeleteAsync(int id) => throw new NotImplementedException();
}