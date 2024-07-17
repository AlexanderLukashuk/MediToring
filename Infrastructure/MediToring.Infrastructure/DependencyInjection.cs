namespace MediToring.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        InitializeDbContext(services, configuration);
        AddRepositories(services);

        return services;
    }

    private static void InitializeDbContext(IServiceCollection services, IConfiguration configuration)
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
    }

    private static void AddRepositories(IServiceCollection services)
    {
        services.AddScoped<IMedicationScheduleRepository, MedicationScheduleRepository>();
        services.AddScoped<IMedicationRepository, MedicationRepository>();
        services.AddScoped<IProfileRepository, ProfileRepository>();
        services.AddScoped<IDoctorApplicationRepository, DoctorApplicationRepository>();
        services.AddScoped<IDoctorProfileRepository, DoctorProfileRepository>();
    }
}