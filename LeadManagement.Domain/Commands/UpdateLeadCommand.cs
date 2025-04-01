using LeadManagement.Domain.Enums;
using MediatR;

namespace LeadManagement.Domain.Commands;

public record UpdateLeadCommand(
    Guid Id,
    string FirstName,
    string FullName,
    string PhoneNumber,
    string Email,
    string Suburb,
    string Category,
    string Description,
    decimal Price,
    ELeadStatus Status
) : IRequest;
