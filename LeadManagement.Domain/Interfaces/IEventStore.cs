namespace LeadManagement.Domain.Interfaces;

public interface IEventStore
{
    Task SaveAsync(IEnumerable<IDomainEvent> events, CancellationToken cancellationToken = default);
    Task<IEnumerable<IDomainEvent>> LoadAsync(Guid aggregateId, CancellationToken cancellationToken = default);
    Task<IEnumerable<IDomainEvent>> LoadAllAsync(CancellationToken cancellationToken = default);
}
