using Microsoft.EntityFrameworkCore;
using VeeArc.Domain.Entities;
using VeeArc.Infrastructure.Common.Interfaces;

namespace VeeArc.Infrastructure.DataBase.Repositories;

public class RolesRepository : BaseDbRepository<Role>
{
    public RolesRepository(IApplicationDbContext dbContext) : base(dbContext, dbContext.Roles)
    {
    }
}
