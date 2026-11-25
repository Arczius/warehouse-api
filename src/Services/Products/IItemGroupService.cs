namespace CargoHub.Services.Products;

using Dtos.Products;

public interface IItemGroupService
{
    Task<List<ItemGroupDtos>> GetAllAsync();
    Task<ItemGroupDtos?> GetByIdAsync(int id);
    Task<ItemGroupDtos> CreateAsync(CreateItemGroupDtos dto);
    Task<bool> DeleteAsync(int id);
    Task<ItemGroupDtos?> UpdateAsync(int id, UpdateItemGroupDtos dto);
}
