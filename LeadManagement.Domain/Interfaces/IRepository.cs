namespace LeadManagement.Domain.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task AddAsync(T entity, CancellationToken cancellation = default);
        Task<T> GetAsync(Guid id, CancellationToken cancellation = default);
        Task UpdateAsync(T entity, CancellationToken cancellation = default);
    }
}
