using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using VeeArc.Application.Common.Interfaces;
using VeeArc.Domain.Common;
using VeeArc.Infrastructure.Common.Interfaces;

namespace VeeArc.Infrastructure.DataBase.Repositories;

public class BaseDbRepository<T> : IRepository<T> where T : BaseEntity
{
    private readonly IApplicationDbContext _dbContext;
    
    protected readonly DbSet<T> DbSet;

    public BaseDbRepository(IApplicationDbContext dbContext, DbSet<T> dbSet)
    {
        _dbContext = dbContext;
        DbSet = dbSet;
    }

    public void Update(T entity)
    {
        DbSet.Update(entity);
    }

    public async Task AddAsync(T entity)
    {
        await DbSet.AddAsync(entity);
    }

    public async Task AddRangeAsync(IEnumerable<T> entities)
    {
        await DbSet.AddRangeAsync(entities);
    }

    public async Task<T> GetById(int id)
    {
        return await IncludeProperties(DbSet).FirstAsync(entity => entity.Id == id);
    }

    public IQueryable<T> GetAllAsync()
    {
        return IncludeProperties(DbSet);
    }

    public async Task SaveAsync()
    {
        await _dbContext.SaveAsync();
    }

    protected virtual IQueryable<T> IncludeProperties(DbSet<T> dbSet)
    {
        return dbSet.AsQueryable();
    }
}
