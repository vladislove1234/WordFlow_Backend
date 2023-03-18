using VeeArc.Domain.Common;

namespace VeeArc.Application.Common.Interfaces;

public interface IRepository<T> where T : BaseEntity
{
    void UpdateAsync(T entity);

    Task AddAsync(T entity);

    Task AddRangeAsync(IEnumerable<T> entities);

    Task<T> GetById(int id);
    
    IQueryable<T> GetAllAsync();

    Task SaveAsync();
}