namespace Warehouse.Services.Products;

using Dtos.Products;
using Models.Products;
using Repositories;

public class ItemGroupService : IItemGroupService
{
    private readonly IRepository<ItemGroup> _itemGroups;

    public ItemGroupService(IRepository<ItemGroup> itemGroups)
    {
        _itemGroups = itemGroups;
    }

    public async Task<List<ItemGroupDtos>> GetAllAsync()
    {
        var itemGroups = await _itemGroups.GetAllAsync();
        return itemGroups.Select(ToDto).ToList();
    }

    public async Task<ItemGroupDtos?> GetByIdAsync(int id)
    {
        var itemGroup = await _itemGroups.GetByIdAsync(id);
        return itemGroup is null ? null : ToDto(itemGroup);
    }

    public async Task<ItemGroupDtos> CreateAsync(CreateItemGroupDtos dto)
    {
        var itemGroup = new ItemGroup
        {
            Name = dto.Name,
            Description = dto.Description,
            CreatedAt = dto.CreatedAt,
            UpdatedAt = dto.UpdatedAt,
        };

        _itemGroups.Add(itemGroup);
        await _itemGroups.SaveChangesAsync();

        return ToDto(itemGroup);
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var itemGroup = await _itemGroups.GetByIdAsync(id);
        if (itemGroup is null) return false;

        _itemGroups.Delete(itemGroup);
        await _itemGroups.SaveChangesAsync();

        return true;
    }

    public async Task<ItemGroupDtos?> UpdateAsync(int id, UpdateItemGroupDtos dto)
    {
        var itemGroup = await _itemGroups.GetByIdAsync(id);
        if (itemGroup is null) return null;

        itemGroup.Name = dto.Name;
        itemGroup.Description = dto.Description;
        itemGroup.CreatedAt = dto.CreatedAt;
        itemGroup.UpdatedAt = dto.UpdatedAt;

        await _itemGroups.SaveChangesAsync();
        return ToDto(itemGroup);
    }

    private static ItemGroupDtos ToDto(ItemGroup itemGroup) => new()
    {
        Id = itemGroup.Id,
        Name = itemGroup.Name,
        Description = itemGroup.Description,
        CreatedAt = itemGroup.CreatedAt,
        UpdatedAt = itemGroup.UpdatedAt,
    };
}
