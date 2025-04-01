using LeadManagement.Domain.Entities;
using MediatR;

namespace LeadManagement.Domain.Queries
{
    public record GetLeadByIdQuery(Guid Id) : IRequest<Lead>;
}
