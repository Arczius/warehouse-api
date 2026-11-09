using Warehouse.Repositories;
using Warehouse.Models.Products;

namespace Warehouse.RouteGroups;

public static class ItemLineGroup
{
    public static RouteGroupBuilder MapItemLineGroup(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/api/v1/itemlines");

        group.MapGetAll<ItemLine>("/");
        group.MapGetById<ItemLine>("/{id}");
        group.MapGetSubResource<ItemLine, Item>("/{id}/items", id => item => item.ItemLineId == id);
        group.Post<ItemLine>("/", "itemlines");
        group.Delete<ItemLine>("/{id}");

        group.MapPut("/{id:int}", async (int id, ItemLine itemLine, IRepository<ItemLine> repo) =>
        {
            var existingItemLine = await repo.GetByIdAsync(id);
            if (existingItemLine is null) return Results.NotFound();

            existingItemLine.Name = itemLine.Name;
            existingItemLine.Description = itemLine.Description;
            await repo.SaveChangesAsync();

            return Results.NoContent();
        });

        return group;
    }
}

