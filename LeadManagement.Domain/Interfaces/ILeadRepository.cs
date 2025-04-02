using LeadManagement.Domain.Entities;
using LeadManagement.Domain.Enums;

namespace LeadManagement.Domain.Interfaces
{
    public interface ILeadRepository
    {
        Task<IEnumerable<Lead>> GetAllByStatusAsync(ELeadStatus status, CancellationToken cancellation = default);
    }
}
