using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using VeeArc.Application.Common.Interfaces;
using VeeArc.Infrastructure.Common.Interfaces;
using VeeArc.Infrastructure.DataBase;
using VeeArc.Infrastructure.DataBase.Repositories;
using VeeArc.Infrastructure.Extensions;

namespace VeeArc.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.ConfigureApplicationDbContext(configuration);
        
        services.AddScoped<IApplicationDbContext>(provider => provider.GetRequiredService<ApplicationDbContext>());

        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IRoleRepository, RolesRepository>();
        services.AddScoped<IArticleRepository, ArticleRepository>();

        return services;
    }
}
