using Microsoft.EntityFrameworkCore;
using VeeArc.Domain.Entities;

namespace VeeArc.Infrastructure.Common.Interfaces;

public interface IApplicationDbContext
{
    public DbSet<Article> Articles { get; }

    public DbSet<User> Users { get; }

    public DbSet<Role> Roles { get; }

    public Task SaveAsync();
}
