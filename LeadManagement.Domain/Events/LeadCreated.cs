using LeadManagement.Domain.Enums;
using LeadManagement.Domain.Interfaces;

namespace LeadManagement.Domain.Events;

public class LeadCreated : IDomainEvent
{
    public Guid Id { get; }
    public string FirstName { get; }
    public string FullName { get; }
    public string PhoneNumber { get; }
    public string Email { get; }
    public string Suburb { get; }
    public string Category { get; }
    public string Description { get; }
    public ELeadStatus Status { get; }
    public decimal Price { get; }
    public DateTime OccurredOn { get; }

    public Guid AggregateId => Id;

    public LeadCreated(Guid id, string firstName, string fullName, string phoneNumber, string email, string suburb, string category, string description, decimal price, ELeadStatus status, DateTime createDate)
    {
        Id = id;
        FirstName = firstName;
        FullName = fullName;
        PhoneNumber = phoneNumber;
        Email = email;
        Suburb = suburb;
        Category = category;
        Description = description;
        Price = price;
        Status = status;
    }
}
