using VeeArc.Application.Common.Interfaces;
using VeeArc.Domain.Entities;
using VeeArc.Infrastructure.Common.Interfaces;

namespace VeeArc.Infrastructure.DataBase.Repositories;

public class RolesRepository : BaseDbRepository<Role>, IRoleRepository
{
    public RolesRepository(IApplicationDbContext dbContext) : base(dbContext, dbContext.Roles)
    {
    }
}
