using LeadManagement.Domain.Entities;
using MediatR;

namespace LeadManagement.Domain.Queries;

public class GetLeadByIdQuery : IRequest<Lead>
{
    public Guid Id { get; set; }

    public GetLeadByIdQuery(Guid id)
    {
        Id = id;
    }
}
