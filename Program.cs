namespace CargoHub;

using Data;
using RouteGroups;

public class Program
{
    private static readonly WebApplicationBuilder s_builder = WebApplication.CreateBuilder();
    private static WebApplication? s_app;
    private static RouteGroupBuilder? s_api;

    public static async Task Main()
    {
        s_builder.Services.AddOpenApi();
        s_builder.Services.AddDbContext<AppDbContext>(options => options.UseNpgsql(s_builder.Configuration.GetConnectionString("DefaultConnection")));
        s_app = s_builder.Build();
        await RunMigrations();

        ImplementOpenApi(s_app);

        s_app.UseHttpsRedirection();

        s_api = s_app.MapGroup("/api/v1");

        s_api.MapWarehouseGroup();

        s_app.Run();
    }

    private static void ImplementOpenApi(WebApplication app)
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

    private static async Task RunMigrations()
    {
        if (s_app == null)
        {
            return;
        }
        var scope = s_app.Services.CreateScope();
        var db = scope.ServiceProvider
            .GetRequiredService<AppDbContext>();

        await db.Database.MigrateAsync();
    }
}
