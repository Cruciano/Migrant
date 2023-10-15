using System.Reflection;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace MigrantCore;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddMigrantCore(this IServiceCollection services, string connectionString)
    {
        services.AddDbContext<MigrantCoreContext>(
            opt => opt.UseSqlite(connectionString));
        
        services.AddMediatR(cfg=>cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
        
        return services;
    }
}