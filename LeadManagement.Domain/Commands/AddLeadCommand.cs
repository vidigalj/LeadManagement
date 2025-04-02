using MediatR;

namespace LeadManagement.Domain.Commands;

public class AddLeadCommand : IRequest<Guid>
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
}
