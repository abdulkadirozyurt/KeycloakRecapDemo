using Scalar.AspNetCore;

namespace KeycloakRecapDemo.WebAPI.Middlewares;

public static class ScalarMiddleware
{
    public static void UseScalarMiddleware(this WebApplication app)
    {
        app.MapScalarApiReference(options =>
        {
            options.Theme = ScalarTheme.Mars;
            options.DarkMode = true;
            // options.AddServer(
            //     new ScalarServer("https://localhost:7251", "Local HTTPS Development Server")
            // );
            options.AddServer(
                new ScalarServer("http://localhost:5090", "Local HTTP Development Server")
            );

            options.AddDocument("v1", "v1-document", "/openapi/v1.json");
            options.AddDocument("v2", "v2-document", "/openapi/v2.json");
        });
    }
}
