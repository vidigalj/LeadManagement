namespace LeadManagement.Domain.Entities;

public class EventEntity
{
    public Guid Id { get; set; }
    public Guid AggregateId { get; set; }
    public DateTime OccurredOn { get; set; }
#nullable disable
    public string EventType { get; set; }
    public string Data { get; set; }
#nullable enable
}
