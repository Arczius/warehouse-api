using Warehouse.Repositories;
using Warehouse.Models.Products;

namespace Warehouse.RouteGroups;

public static class ItemGroup
{
    public static RouteGroupBuilder MapItemGroup(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/api/v1/items");

        group.MapGetAll<Item>("/");
        group.MapGetById<Item>("/{id}");
        group.Post<Item>("/", "items");
        group.Delete<Item>("/{id}");

        // VV moet nog aangepast worden VV
        // group.MapGetById<Item>("/{id}/inventory");
        // group.MapGetById<Item>("/{id}/inventory/totals");

        group.MapPut("/{id:int}", async (int id, Item item, IRepository<Item> repo) =>
        {
            var existingItem = await repo.GetByIdAsync(id);
            if (existingItem is null) return Results.NotFound();

            existingItem.ItemLineId = item.ItemLineId;
            existingItem.ItemGroupId = item.ItemGroupId;
            existingItem.ItemTypeId = item.ItemTypeId;
            existingItem.SupplierId = item.SupplierId;
            existingItem.Code = item.Code;
            existingItem.Description = item.Description;
            existingItem.Barcode = item.Barcode;
            existingItem.ModelNumber = item.ModelNumber;
            existingItem.CommodityCode = item.CommodityCode;
            existingItem.UnitWeight = item.UnitWeight;
            existingItem.MinPurchaseQty = item.MinPurchaseQty;
            existingItem.CaseSize = item.CaseSize;
            existingItem.PackagingType = item.PackagingType;
            existingItem.OrderMultiple = item.OrderMultiple;
            existingItem.SupplierSku = item.SupplierSku;
            await repo.SaveChangesAsync();

            return Results.NoContent();
        });

        return group;
    }
}

