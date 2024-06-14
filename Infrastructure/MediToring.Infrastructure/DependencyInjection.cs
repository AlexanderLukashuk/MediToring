using MediToring.Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MediToring.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DbConnection");

        services.AddDbContext<MediToringDbContext>(options =>
            options.UseNpgsql(connectionString));

        services.AddScoped<IMediToringDbContext>(provider =>
        {
            var context = provider.GetService<MediToringDbContext>();
            if (context == null)
            {
                throw new InvalidOperationException("MediToringDbContext is not registered");
            }
            
            return context;
        });

        return services;
    }
}