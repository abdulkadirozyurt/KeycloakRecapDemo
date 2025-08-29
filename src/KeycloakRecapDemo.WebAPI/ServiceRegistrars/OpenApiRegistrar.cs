using System;
using Microsoft.OpenApi.Models;

namespace KeycloakRecapDemo.WebAPI.ServiceRegistrars;

public static class OpenApiRegistrar
{
    public static IServiceCollection AddOpenApiServices(this IServiceCollection services)
    {
        services.AddOpenApi("v1", options =>
            {
                options.AddDocumentTransformer(
                    (document, context, cancellationToken) =>
                    {
                        document.Info = new OpenApiInfo
                        {
                            Title = "Keycloak Recap Demo API",
                            Version = "v1",
                            Description =
                                "A simple example ASP.NET Core Web API Demo Project for Keycloak",
                            Contact = new OpenApiContact { Name = "Abdulkadir Özyurt" },
                        };
                        return Task.CompletedTask;
                    }
                );

                options.AddDocumentTransformer((document, context, cancellationToken) =>
                    {
                        document.Components ??= new OpenApiComponents();
                        document.Components.SecuritySchemes["Bearer"] = new OpenApiSecurityScheme
                        {
                            Type = SecuritySchemeType.Http,
                            Scheme = "bearer",
                            BearerFormat = "JWT",
                            In = ParameterLocation.Header,
                            Description = "Authorization JWT Beaarer token",
                        };

                        document.SecurityRequirements.Add(new OpenApiSecurityRequirement
                            {
                                {
                                    new OpenApiSecurityScheme
                                    {
                                        Reference = new OpenApiReference
                                        {
                                            Type = ReferenceType.SecurityScheme,
                                            Id = "Bearer",
                                        },
                                    },
                                    Array.Empty<string>()
                                },
                            }
                        );
                        return Task.CompletedTask;
                    }
                );
            }
        );

        return services;
    }
}
