using Keycloak.AuthServices.Authentication;
using KeycloakRecapDemo.WebAPI.Middlewares;
using KeycloakRecapDemo.WebAPI.ServiceRegistrars;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddOpenApiServices();

var app = builder.Build();

// if (app.Environment.IsDevelopment())
// {
//     app.MapOpenApi();
// }


app.MapOpenApi();

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.UseScalarMiddleware();

app.MapControllers();

app.Run();
