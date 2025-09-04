using System;
using Microsoft.Extensions.DependencyInjection;
using TS.MediatR;

namespace KeycloakRecapDemo.Application;

public static class ApplicationRegistrar
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
{
    services.AddMediatR(options=>
    {
        options.RegisterServicesFromAssembly(typeof(ApplicationRegistrar).Assembly);
    });
    return services;
}
}

