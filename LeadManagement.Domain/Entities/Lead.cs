using LeadManagement.Domain.Enums;
using LeadManagement.Domain.Events;
using LeadManagement.Domain.Interfaces;

namespace LeadManagement.Domain.Entities;

public class Lead : EntityBase
{
#nullable disable
    public string FirstName { get; set; }
    public string FullName { get; set; }
    public string PhoneNumber { get; set; }
    public string Email { get; set; }
    public string Suburb { get; set; }
    public string Category { get; set; }
    public string Description { get; set; }
#nullable enable
    public decimal Price { get; set; }
    public ELeadStatus Status { get; set; }

    private List<IDomainEvent> _domainEvents = new List<IDomainEvent>();
    public IReadOnlyCollection<IDomainEvent> DomainEvents => _domainEvents.AsReadOnly();

    public Lead() { }

    public void Update(string firstName, string fullName, string phoneNumber, string email, string suburb, string category, string description, decimal price, ELeadStatus status, DateTime updateDate)
    {
        Apply(new LeadUpdated(Id, firstName, fullName, phoneNumber, email, suburb, category, description, price, status, updateDate));
    }

    public void Apply(IDomainEvent @event)
    {
        When(@event);
        _domainEvents.Add(@event);
    }

    private void When(IDomainEvent @event)
    {
        switch (@event)
        {
            case LeadUpdated e:
                FirstName = e.FirstName;
                FullName = e.FullName;
                PhoneNumber = e.PhoneNumber;
                Email = e.Email;
                Suburb = e.Suburb;
                Category = e.Category;
                Description = e.Description;
                Price = e.Price;
                Status = e.Status;
                UpdateDate = e.OccurredOn;
                break;
        }
    }

    public void ApplyDiscount(decimal discountRate, decimal minPriceDiscount)
    {
        if (Price > minPriceDiscount)
        {
            Price *= discountRate;
        }
    }
}
