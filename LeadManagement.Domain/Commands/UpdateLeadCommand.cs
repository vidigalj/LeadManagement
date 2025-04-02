using LeadManagement.Domain.Enums;
using MediatR;

namespace LeadManagement.Domain.Commands;

public class UpdateLeadCommand : IRequest<Unit>
{
    public Guid Id { get; set; }
#nullable disable
    public string FirstName { get; set; }
    public string FullName { get; set; }
    public string PhoneNumber { get; set; }
    public string Email { get; set; }
    public string Suburb { get; set; }
    public string Category { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
#nullable enable
    public ELeadStatus Status { get; set; }
}