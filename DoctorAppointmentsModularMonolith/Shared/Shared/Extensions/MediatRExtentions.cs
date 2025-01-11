﻿using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Shared.Extensions;
public static class MediatRExtentions
{
    public static IServiceCollection AddMediatRWithAssemblies
        (this IServiceCollection services, params Assembly[] assemblies)
    {
        services.AddMediatR(config =>
        {
            config.RegisterServicesFromAssemblies(assemblies);

        });



        return services;
    }
}
