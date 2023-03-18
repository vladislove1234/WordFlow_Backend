using Microsoft.EntityFrameworkCore;
using VeeArc.Domain.Entities;
using VeeArc.Infrastructure.Common.Interfaces;
using VeeArc.Infrastructure.Persistence.Interceptors;

namespace VeeArc.Infrastructure.DataBase;

public class ApplicationDbContext : DbContext, IApplicationDbContext
{
    public DbSet<Article> Articles { get; }
    
    public DbSet<User> Users { get; }
    
    public DbSet<Role> Roles { get; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.AddInterceptors(new AuditableEntitySaveChangesInterceptor());

        base.OnConfiguring(optionsBuilder);
    }
    
    public async Task SaveAsync()
    {
        await SaveChangesAsync();
    }
}