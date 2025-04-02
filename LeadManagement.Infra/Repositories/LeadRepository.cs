using LeadManagement.Domain.Entities;
using LeadManagement.Domain.Enums;
using LeadManagement.Domain.Interfaces;
using LeadManagement.Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace LeadManagement.Infra.Repositories
{
    public class LeadRepository : ILeadRepository
    {
        private readonly LeadDbContext _context;
        private readonly DbSet<Lead> _dbSet;

        public LeadRepository(LeadDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _dbSet = _context.Set<Lead>();
        }

        public async Task<IEnumerable<Lead>> GetAllByStatusAsync(ELeadStatus status, CancellationToken cancellation = default)
        {
            return await _dbSet.OfType<Lead>().Where(lead => lead.Status == status).ToListAsync(cancellation);
        }
    }
}
