using Keycloak.AuthServices.Authentication;
using Keycloak.AuthServices.Authorization;
using KeycloakRecapDemo.Application;
using KeycloakRecapDemo.Infrastructure;
using KeycloakRecapDemo.WebAPI.Middlewares;
using KeycloakRecapDemo.WebAPI.ServiceRegistrars;
using Microsoft.AspNetCore.Authentication.JwtBearer;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

builder.Services.AddApplicationServices();
builder.Services.AddInfrastructureServices(configuration);


builder.Services.AddKeycloakWebApiAuthentication(configuration, options =>
    {
        if (builder.Environment.IsDevelopment())
        {
            options.RequireHttpsMetadata = false; // Sadece development için HTTPS zorunluluğunu kaldır
        }
    }
);


builder.Services.AddKeycloakAuthorization(configuration);


builder.Services.AddControllers();
builder.Services.AddOpenApiServices();

var app = builder.Build();



app.MapOpenApi();

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.UseScalarMiddleware();

app.MapControllers().RequireAuthorization();

app.Run();
