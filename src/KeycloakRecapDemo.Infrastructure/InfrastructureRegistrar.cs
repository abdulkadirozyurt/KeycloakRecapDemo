using KeycloakRecapDemo.Application.Services;
using KeycloakRecapDemo.Infrastructure.Context;
using KeycloakRecapDemo.Infrastructure.Options;
using KeycloakRecapDemo.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace KeycloakRecapDemo.Infrastructure;

public static class InfrastructureRegistrar
{
    public static void AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDbContext>(options =>
        {
            string connectionString = configuration.GetConnectionString("PostgreSql")!;
            options.UseNpgsql(connectionString);
        });
        services.Configure<KeycloakConfiguration>(configuration.GetSection("Keycloak"));
        services.AddScoped<IJwtProvider, KeycloakService>();
    }


























}