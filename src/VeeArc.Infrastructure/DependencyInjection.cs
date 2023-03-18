using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using VeeArc.Infrastructure.Common.Interfaces;
using VeeArc.Infrastructure.DataBase;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using VeeArc.Application.Common.Interfaces;
using VeeArc.Domain.Entities;
using VeeArc.Infrastructure.DataBase.Repositories;
using VeeArc.Infrastructure.Persistence.Interceptors;

namespace VeeArc.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        if (configuration.GetValue<bool>("UseInMemory"))
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseInMemoryDatabase("CleanArchitectureDb")
                       .AddInterceptors(new AuditableEntitySaveChangesInterceptor()));
        }
        else
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"))
                       .AddInterceptors(new AuditableEntitySaveChangesInterceptor()));
        }

        services.AddScoped<IApplicationDbContext>(provider => provider.GetRequiredService<ApplicationDbContext>());

        services.AddScoped<IRepository<User>, UserRepository>();
        services.AddScoped<IRepository<Role>, RolesRepository>();
        services.AddScoped<IRepository<Article>, ArticleRepository>();
        
        return services;
    }
}
