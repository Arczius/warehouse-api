using Warehouse.Models.Warehouses;
using Warehouse.Repositories;

namespace Warehouse.RouteGroups;

public static class WarehouseGroup
{
    public static RouteGroupBuilder MapWarehouseGroup(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/api/v1/warehouses");

        group.MapGetAll<Models.Warehouses.Warehouse>("/");
        group.MapGetById<Models.Warehouses.Warehouse>("/{id}");
        group.MapGetSubResource<Models.Warehouses.Warehouse, Location>("/{id}/locations", id => location => location.WarehouseId == id);
        group.Post<Models.Warehouses.Warehouse>("/", "warehouses");
        group.Delete<Models.Warehouses.Warehouse>("/{id}");

        group.MapPut("/{id:int}", async (int id, Models.Warehouses.Warehouse warehouse, IRepository<Models.Warehouses.Warehouse> repo) =>
        {
            var existingWarehouse = await repo.GetByIdAsync(id);
            if (existingWarehouse is null) return Results.NotFound();

            existingWarehouse.Name = warehouse.Name;
            existingWarehouse.Code = warehouse.Code;
            existingWarehouse.Address = warehouse.Address;
            existingWarehouse.City = warehouse.City;
            existingWarehouse.ZipCode = warehouse.ZipCode;
            existingWarehouse.Province = warehouse.Province;
            existingWarehouse.Country = warehouse.Country;
            existingWarehouse.ContactName = warehouse.ContactName;
            existingWarehouse.ContactPhone = warehouse.ContactPhone;
            existingWarehouse.ContactEmail = warehouse.ContactEmail;
            await repo.SaveChangesAsync();

            return Results.NoContent();
        });

        return group;
    }
}

