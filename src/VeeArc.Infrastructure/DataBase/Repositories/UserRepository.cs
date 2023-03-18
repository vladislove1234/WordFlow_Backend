using Microsoft.EntityFrameworkCore;
using VeeArc.Domain.Entities;
using VeeArc.Infrastructure.Common.Interfaces;

namespace VeeArc.Infrastructure.DataBase.Repositories;

public class UserRepository : BaseDbRepository<User>
{
    public UserRepository(IApplicationDbContext dbContext) : base(dbContext, dbContext.Users)
    {
    }

    protected override IQueryable<User> IncludeProperties(DbSet<User> dbSet)
    {
        return dbSet.Include(user => user.Roles).AsQueryable();
    }
}