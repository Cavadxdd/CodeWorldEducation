using CodeWorldEducation.Application.Features.Events.Commands.CreateEvent;
using CodeWorldEducation.Application.Features.Events.Commands.UpdateEvent;
using CodeWorldEducation.Application.Features.Events.Commands.DeleteEvent;
using CodeWorldEducation.Domain.Entities;

namespace CodeWorldEducation.Application.Abstraction.Services;

public interface IEventService
{
    Task<List<Event>> GetAllAsync();
    Task<Event?> GetByIdAsync(int id);
    Task<CreateEventCommandResponse> CreateAsync(CreateEventCommandRequest request);
    Task<UpdateEventCommandResponse> UpdateAsync(UpdateEventCommandRequest request);
    Task<DeleteEventCommandResponse> DeleteAsync(int id);
}