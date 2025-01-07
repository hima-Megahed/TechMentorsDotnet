using MassTransit;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Shared.Messaging.Extensions;
public static class MassTransitExtentions
{
    public static IServiceCollection AddMassTransitWithAssemblies
        (this IServiceCollection services, params Assembly[] assemblies)
    {
        services.AddMassTransit(config =>
        {
            config.SetKebabCaseEndpointNameFormatter();


            config.AddConsumers(assemblies);

            config.UsingInMemory((context, configurator) =>
            {
                configurator.ConfigureEndpoints(context);
            });

        });

        return services;
    }
}
