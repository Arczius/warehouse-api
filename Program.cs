namespace Warehouse;

using Warehouse.RouteGroups;

public class Program
{
    private static readonly WebApplicationBuilder s_builder = WebApplication.CreateBuilder();
    private static WebApplication? s_app;

    public static async Task Main()
    {
        s_builder.Services.AddOpenApi();
        s_app = s_builder.Build();

        ImplementOpenApi(s_app);

        s_app.UseHttpsRedirection();

        s_app.MapWarehouseGroup();

        s_app.Run();
    }

    private static void ImplementOpenApi(WebApplication app)
    {
        if (app.Environment.IsDevelopment())
        {
            // map the OpenAPI endpoint
            app.MapOpenApi();

            // Serve the interactive Swagger UI
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint(
                    "/openapi/v1.json",
                    "API v1"
                );
            });
        }
    }
}
