using System.Reflection;
using MediatR;
using MediToring.Application.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace MediToring.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        // старая версия медиатр:
        // services.AddMediatR(Assembly.GetExecutingAssembly());
        // новая версия медиатр:
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
        services.AddTransient<IMediator, Mediator>();

        return services;
    }
}