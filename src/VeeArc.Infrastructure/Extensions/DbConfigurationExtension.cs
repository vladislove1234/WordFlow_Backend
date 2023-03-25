using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using VeeArc.Infrastructure.DataBase;
using VeeArc.Infrastructure.DataBase.Interceptors;

namespace VeeArc.Infrastructure.Extensions;

public static class DbConfigurationExtension
{
    public static IServiceCollection ConfigureApplicationDbContext(this IServiceCollection services, IConfiguration configuration)
    {
        if (configuration.GetValue<bool>("UseInMemory"))
        {
            return services.AddDbContext<ApplicationDbContext>(options =>
                options.UseInMemoryDatabase("CleanArchitectureDb")
                    .AddInterceptors(new AuditableEntitySaveChangesInterceptor()));
        }
        
        return services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"))
                .AddInterceptors(new AuditableEntitySaveChangesInterceptor()));
    }
}
