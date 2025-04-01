using LeadManagement.Domain.Interfaces;
using LeadManagement.Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace LeadManagement.Infra.Repositories;

public class BaseRepository<T> : IRepository<T> where T : class
{
    private readonly LeadDbContext _context;
    private readonly DbSet<T> _dbSet;

    public BaseRepository(LeadDbContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
        _dbSet = _context.Set<T>();
    }

    public async Task AddAsync(T entity, CancellationToken cancellation = default)
    {
        await _dbSet.AddAsync(entity, cancellation);
        await _context.SaveChangesAsync();
    }

    public async Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellation = default)
    {
        return await _dbSet.ToListAsync(cancellation);
    }

    public async Task<T> GetAsync(Guid id, CancellationToken cancellation = default)
    {
        return await _dbSet.FindAsync([id], cancellation);
    }

    public async Task UpdateAsync(T entity, CancellationToken cancellation = default)
    {
        _dbSet.Update(entity);
        await _context.SaveChangesAsync(cancellation);
    }
}
