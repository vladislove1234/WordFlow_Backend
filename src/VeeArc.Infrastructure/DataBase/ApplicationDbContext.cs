using Microsoft.EntityFrameworkCore;
using VeeArc.Domain.Entities;
using VeeArc.Infrastructure.Common.Interfaces;
using VeeArc.Infrastructure.DataBase.Interceptors;

namespace VeeArc.Infrastructure.DataBase;

public class ApplicationDbContext : DbContext, IApplicationDbContext
{
    public DbSet<Article> Articles { get; }

    public DbSet<User> Users { get; }

    public DbSet<Role> Roles { get; }

    public async Task SaveAsync()
    {
        await SaveChangesAsync();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Article>()
            .HasOne(article => article.User)
            .WithMany(user => user.Articles);

        modelBuilder.Entity<Role>()
            .HasMany(role => role.Users)
            .WithMany(user => user.Roles);
    }
}
