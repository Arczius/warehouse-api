using Warehouse.Repositories;
using Warehouse.Models.Warehouses;

namespace Warehouse.RouteGroups;

public static class LocationGroup
{
    public static RouteGroupBuilder MapLocationGroup(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/api/v1/locations");

        group.MapGetAll<Location>("/");
        group.MapGetById<Location>("/{id}");
        group.Post<Location>("/", "locations");
        group.Delete<Location>("/{id}");

        group.MapPut("/{id:int}", async (int id, Location location, IRepository<Location> repo) =>
        {
            var existingLocation = await repo.GetByIdAsync(id);
            if (existingLocation is null) return Results.NotFound();

            existingLocation.WarehouseId = location.WarehouseId;
            existingLocation.Code = location.Code;
            existingLocation.Name = location.Name;

            await repo.SaveChangesAsync();

            return Results.NoContent();
        });

        return group;
    }
}

