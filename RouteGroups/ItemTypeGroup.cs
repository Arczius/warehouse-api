using Warehouse.Repositories;
using Warehouse.Models.Products;

namespace Warehouse.RouteGroups;

public static class ItemTypeGroup
{
    public static RouteGroupBuilder MapItemTypeGroup(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/api/v1/itemtypes");

        group.MapGetAll<ItemType>("/");
        group.MapGetById<ItemType>("/{id}");
        group.MapGetSubResource<ItemType, Item>("/{id}/items", id => item => item.ItemTypeId == id);
        group.Post<ItemType>("/", "itemtypes");
        group.Delete<ItemType>("/{id}");

        group.MapPut("/{id:int}", async (int id, ItemType itemType, IRepository<ItemType> repo) =>
        {
            var existingItemType = await repo.GetByIdAsync(id);
            if (existingItemType is null) return Results.NotFound();

            existingItemType.Name = itemType.Name;
            existingItemType.Description = itemType.Description;
            await repo.SaveChangesAsync();

            return Results.NoContent();
        });

        return group;
    }
}

