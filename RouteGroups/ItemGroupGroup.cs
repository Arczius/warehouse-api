using Warehouse.Models.Products;
using Warehouse.Repositories;

namespace Warehouse.RouteGroups;

public static class ItemGroupGroup
{
    public static RouteGroupBuilder MapItemGroupGroup(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/api/v1/itemgroups");

        group.MapGetAll<Models.Products.ItemGroup>("/");
        group.MapGetById<Models.Products.ItemGroup>("/{id}");
        group.MapGetSubResource<Models.Products.ItemGroup, Item>("/{id}/items", id => item => item.ItemGroupId == id);
        group.Post<Models.Products.ItemGroup>("/", "itemgroups");
        group.Delete<Models.Products.ItemGroup>("/{id}");

        group.MapPut("/{id:int}", async (int id, Models.Products.ItemGroup itemGroup, IRepository<Models.Products.ItemGroup> repo) =>
        {
            var existingItemGroup = await repo.GetByIdAsync(id);
            if (existingItemGroup is null) return Results.NotFound();

            existingItemGroup.Name = itemGroup.Name;
            existingItemGroup.Description = itemGroup.Description;
            await repo.SaveChangesAsync();

            return Results.NoContent();
        });

        return group;
    }
}

