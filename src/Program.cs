namespace CargoHub;

using Data;
using CargoHub.Repositories;
using CargoHub.Services.Orders;
using CargoHub.Services.Products;
using CargoHub.Services.Shipments;
using CargoHub.Services.Suppliers;
using CargoHub.Services.Transfers;
using CargoHub.Services.Warehouses;

public class Program
{
    private static readonly WebApplicationBuilder s_builder = WebApplication.CreateBuilder();
    private static WebApplication? s_app;

    public static async Task Main()
    {
        s_builder.Services.AddOpenApi();
        s_builder.Services.AddControllers();
        s_builder.Services.AddDbContext<AppDbContext>(options => options.UseNpgsql(s_builder.Configuration.GetConnectionString("DefaultConnection")));
        s_builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        s_builder.Services.AddScoped<IClientService, ClientService>();
        s_builder.Services.AddScoped<IOrderService, OrderService>();
        s_builder.Services.AddScoped<IItemService, ItemService>();
        s_builder.Services.AddScoped<IItemGroupService, ItemGroupService>();
        s_builder.Services.AddScoped<IItemLineService, ItemLineService>();
        s_builder.Services.AddScoped<IItemTypeService, ItemTypeService>();
        s_builder.Services.AddScoped<IShipmentService, ShipmentService>();
        s_builder.Services.AddScoped<ISupplierService, SupplierService>();
        s_builder.Services.AddScoped<ITransferService, TransferService>();
        s_builder.Services.AddScoped<IInventoryService, InventoryService>();
        s_builder.Services.AddScoped<ILocationService, LocationService>();
        s_builder.Services.AddScoped<IWarehouseService, WarehouseService>();
        s_app = s_builder.Build();
        await RunMigrations();

        ImplementOpenApi(s_app);

        s_app.UseHttpsRedirection();
        s_app.MapControllers();

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
