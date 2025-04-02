using LeadManagement.Domain.Entities;
using LeadManagement.Domain.Enums;
using MediatR;

namespace LeadManagement.Domain.Queries;

public class GetAllByStatusLeadsQuery : IRequest<IEnumerable<Lead>>
{
    public ELeadStatus Status { get; }
    public GetAllByStatusLeadsQuery(ELeadStatus status)
    {
        Status = status;
    }
}
