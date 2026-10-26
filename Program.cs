namespace Warehouse;

using Warehouse.RouteGroups;

public class Program
{
    private static WebApplicationBuilder Builder = WebApplication.CreateBuilder();
    private static WebApplication? App;

    public static async Task Main()
    {
        Builder.Services.AddOpenApi();
        App = Builder.Build();

        ImplementOpenApi(App);

        App.UseHttpsRedirection();

        App.MapWarehouseGroup();

        App.Run();
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
