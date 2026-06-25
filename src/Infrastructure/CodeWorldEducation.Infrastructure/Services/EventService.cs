using CodeWorldEducation.Application.Abstraction.Services;
using CodeWorldEducation.Application.Features.Events.Commands.CreateEvent;
using CodeWorldEducation.Application.Features.Events.Commands.UpdateEvent;
using CodeWorldEducation.Application.Features.Events.Commands.DeleteEvent;
using CodeWorldEducation.Domain.Entities;

namespace CodeWorldEducation.Infrastructure.Services;

public class EventService : IEventService
{
    public async Task<List<Event>> GetAllAsync() => throw new NotImplementedException();
    public async Task<Event?> GetByIdAsync(int id) => throw new NotImplementedException();
    public async Task<CreateEventCommandResponse> CreateAsync(CreateEventCommandRequest request) => throw new NotImplementedException();
    public async Task<UpdateEventCommandResponse> UpdateAsync(UpdateEventCommandRequest request) => throw new NotImplementedException();
    public async Task<DeleteEventCommandResponse> DeleteAsync(int id) => throw new NotImplementedException();
}