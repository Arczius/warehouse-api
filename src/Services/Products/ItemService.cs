namespace CargoHub.Services.Products;

using Dtos.Products;
using Models.Products;
using Repositories;

public class ItemService : IItemService
{
    private readonly IRepository<Item> _items;

    public ItemService(IRepository<Item> items)
    {
        _items = items;
    }

    public async Task<List<ItemDTO>> GetAllAsync()
    {
        var items = await _items.GetAllAsync();
        return items.Select(ToDto).ToList();
    }

    public async Task<ItemDTO?> GetByIdAsync(int id)
    {
        var item = await _items.GetByIdAsync(id);
        return item is null ? null : ToDto(item);
    }

    public async Task<ItemDTO> CreateAsync(CreateItemDTO dto)
    {
        var item = new Item
        {
            ItemLineId = dto.ItemLineId,
            ItemGroupId = dto.ItemGroupId,
            ItemTypeId = dto.ItemTypeId,
            SupplierId = dto.SupplierId,
            Code = dto.Code,
            Description = dto.Description,
            Barcode = dto.Barcode,
            ModelNumber = dto.ModelNumber,
            CommodityCode = dto.CommodityCode,
            UnitWeight = dto.UnitWeight,
            MinPurchaseQty = dto.MinPurchaseQty,
            CaseSize = dto.CaseSize,
            PackagingType = dto.PackagingType,
            OrderMultiple = dto.OrderMultiple,
            SupplierSku = dto.SupplierSku,
            CreatedAt = dto.CreatedAt,
            UpdatedAt = dto.UpdatedAt,
        };

        _items.Add(item);
        await _items.SaveChangesAsync();

        return ToDto(item);
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var item = await _items.GetByIdAsync(id);
        if (item is null) return false;

        _items.Delete(item);
        await _items.SaveChangesAsync();

        return true;
    }

    public async Task<ItemDTO?> UpdateAsync(int id, UpdateItemDTO dto)
    {
        var item = await _items.GetByIdAsync(id);
        if (item is null) return null;

        item.ItemLineId = dto.ItemLineId;
        item.ItemGroupId = dto.ItemGroupId;
        item.ItemTypeId = dto.ItemTypeId;
        item.SupplierId = dto.SupplierId;
        item.Code = dto.Code;
        item.Description = dto.Description;
        item.Barcode = dto.Barcode;
        item.ModelNumber = dto.ModelNumber;
        item.CommodityCode = dto.CommodityCode;
        item.UnitWeight = dto.UnitWeight;
        item.MinPurchaseQty = dto.MinPurchaseQty;
        item.CaseSize = dto.CaseSize;
        item.PackagingType = dto.PackagingType;
        item.OrderMultiple = dto.OrderMultiple;
        item.SupplierSku = dto.SupplierSku;
        item.CreatedAt = dto.CreatedAt;
        item.UpdatedAt = dto.UpdatedAt;

        await _items.SaveChangesAsync();
        return ToDto(item);
    }

    private static ItemDTO ToDto(Item item) => new()
    {
        Id = item.Id,
        ItemLineId = item.ItemLineId,
        ItemGroupId = item.ItemGroupId,
        ItemTypeId = item.ItemTypeId,
        SupplierId = item.SupplierId,
        Code = item.Code,
        Description = item.Description,
        Barcode = item.Barcode,
        ModelNumber = item.ModelNumber,
        CommodityCode = item.CommodityCode,
        UnitWeight = item.UnitWeight,
        MinPurchaseQty = item.MinPurchaseQty,
        CaseSize = item.CaseSize,
        PackagingType = item.PackagingType,
        OrderMultiple = item.OrderMultiple,
        SupplierSku = item.SupplierSku,
        CreatedAt = item.CreatedAt,
        UpdatedAt = item.UpdatedAt,
    };
}
