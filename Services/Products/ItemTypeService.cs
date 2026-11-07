namespace Warehouse.Services.Products;

using Dtos.Products;
using Models.Products;
using Repositories;

public class ItemTypeService : IItemTypeService
{
    private readonly IRepository<ItemType> _itemTypes;

    public ItemTypeService(IRepository<ItemType> itemTypes)
    {
        _itemTypes = itemTypes;
    }

    public async Task<List<ItemTypeDTO>> GetAllAsync()
    {
        var itemTypes = await _itemTypes.GetAllAsync();
        return itemTypes.Select(ToDto).ToList();
    }

    public async Task<ItemTypeDTO?> GetByIdAsync(int id)
    {
        var itemType = await _itemTypes.GetByIdAsync(id);
        return itemType is null ? null : ToDto(itemType);
    }

    public async Task<ItemTypeDTO> CreateAsync(CreateItemTypeDTO dto)
    {
        var itemType = new ItemType
        {
            Name = dto.Name,
            Description = dto.Description,
            CreatedAt = dto.CreatedAt,
            UpdatedAt = dto.UpdatedAt,
        };

        _itemTypes.Add(itemType);
        await _itemTypes.SaveChangesAsync();

        return ToDto(itemType);
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var itemType = await _itemTypes.GetByIdAsync(id);
        if (itemType is null) return false;

        _itemTypes.Delete(itemType);
        await _itemTypes.SaveChangesAsync();

        return true;
    }

    public async Task<ItemTypeDTO?> UpdateAsync(int id, UpdateItemTypeDTO dto)
    {
        var itemType = await _itemTypes.GetByIdAsync(id);
        if (itemType is null) return null;

        itemType.Name = dto.Name;
        itemType.Description = dto.Description;
        itemType.CreatedAt = dto.CreatedAt;
        itemType.UpdatedAt = dto.UpdatedAt;

        await _itemTypes.SaveChangesAsync();
        return ToDto(itemType);
    }

    private static ItemTypeDTO ToDto(ItemType itemType) => new()
    {
        Id = itemType.Id,
        Name = itemType.Name,
        Description = itemType.Description,
        CreatedAt = itemType.CreatedAt,
        UpdatedAt = itemType.UpdatedAt,
    };
}
