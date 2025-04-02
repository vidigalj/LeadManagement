using LeadManagement.Domain.Enums;

namespace LeadManagement.Domain.Interfaces;

public interface IDomainEvent
{
    ELeadStatus Status { get; }
    decimal Price { get; }
    Guid AggregateId { get; }
    DateTime OccurredOn { get; }
}
