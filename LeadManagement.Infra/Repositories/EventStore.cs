using LeadManagement.Domain.Entities;
using LeadManagement.Domain.Interfaces;
using LeadManagement.Infra.Context;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace LeadManagement.Infra.Repositories
{
    public class EventStore : IEventStore
    {
        private readonly LeadDbContext _context;

        public EventStore(LeadDbContext context)
        {
            _context = context;
        }

        public async Task SaveAsync(IEnumerable<IDomainEvent> events, CancellationToken cancellationToken = default)
        {
            foreach (var @event in events)
            {
                await _context.Events.AddAsync(new EventEntity
                {
                    AggregateId = @event.AggregateId,
                    OccurredOn = @event.OccurredOn,
                    EventType = @event.GetType().Name,
                    Data = JsonSerializer.Serialize(@event)
                }, cancellationToken);
            }
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task<IEnumerable<IDomainEvent>> LoadAsync(Guid aggregateId, CancellationToken cancellationToken = default)
        {
            var eventEntities = await _context.Events
                .Where(e => e.AggregateId == aggregateId)
                .ToListAsync(cancellationToken);

            return eventEntities.Select(e => JsonSerializer.Deserialize<IDomainEvent>(e.Data)!);
        }

        public async Task<IEnumerable<IDomainEvent>> LoadAllAsync(CancellationToken cancellationToken = default)
        {
            var eventEntities = await _context.Events.ToListAsync(cancellationToken);
            return eventEntities.Select(e => JsonSerializer.Deserialize<IDomainEvent>(e.Data)!);
        }
    }
}
