using Warehouse.Repositories;
using Warehouse.Models.Warehouses;
using Warehouse.Data;

namespace Warehouse.RouteGroups;

public static class InventoryGroup
{
    public static RouteGroupBuilder MapInventoryGroup(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/api/v1/inventories");

        group.MapGet("/", async (AppDbContext db) =>
        {
            var existingWarehouse = await db.Inventories.ToListAsync();
            return Results.Ok(existingWarehouse);
        });

        group.MapPost("/", async (Inventory inventory, AppDbContext db) =>
        {
            db.Add(inventory);
            await db.SaveChangesAsync();
            return Results.Created($"/api/v1/inventories/{inventory.ItemId}/{inventory.LocationId}", inventory);
        });

        return group;
    }
}

