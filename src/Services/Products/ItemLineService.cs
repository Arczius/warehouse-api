namespace CargoHub.Services.Products;

using Dtos.Products;
using Models.Products;
using Repositories;

public class ItemLineService : IItemLineService
{
    private readonly IRepository<ItemLine> _itemLines;

    public ItemLineService(IRepository<ItemLine> itemLines)
    {
        _itemLines = itemLines;
    }

    public async Task<List<ItemLineDTO>> GetAllAsync()
    {
        var itemLines = await _itemLines.GetAllAsync();
        return itemLines.Select(ToDto).ToList();
    }

    public async Task<ItemLineDTO?> GetByIdAsync(int id)
    {
        var itemLine = await _itemLines.GetByIdAsync(id);
        return itemLine is null ? null : ToDto(itemLine);
    }

    public async Task<ItemLineDTO> CreateAsync(CreateItemLineDTO dto)
    {
        var itemLine = new ItemLine
        {
            Name = dto.Name,
            Description = dto.Description,
            CreatedAt = dto.CreatedAt,
            UpdatedAt = dto.UpdatedAt,
        };

        _itemLines.Add(itemLine);
        await _itemLines.SaveChangesAsync();

        return ToDto(itemLine);
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var itemLine = await _itemLines.GetByIdAsync(id);
        if (itemLine is null) return false;

        _itemLines.Delete(itemLine);
        await _itemLines.SaveChangesAsync();

        return true;
    }

    public async Task<ItemLineDTO?> UpdateAsync(int id, UpdateItemLineDTO dto)
    {
        var itemLine = await _itemLines.GetByIdAsync(id);
        if (itemLine is null) return null;

        itemLine.Name = dto.Name;
        itemLine.Description = dto.Description;
        itemLine.CreatedAt = dto.CreatedAt;
        itemLine.UpdatedAt = dto.UpdatedAt;

        await _itemLines.SaveChangesAsync();
        return ToDto(itemLine);
    }

    private static ItemLineDTO ToDto(ItemLine itemLine) => new()
    {
        Id = itemLine.Id,
        Name = itemLine.Name,
        Description = itemLine.Description,
        CreatedAt = itemLine.CreatedAt,
        UpdatedAt = itemLine.UpdatedAt,
    };
}
