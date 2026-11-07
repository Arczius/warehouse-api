namespace CargoHub.Services.Products;

using Dtos.Products;

public interface IItemService
{
    Task<List<ItemDTO>> GetAllAsync();
    Task<ItemDTO?> GetByIdAsync(int id);
    Task<ItemDTO> CreateAsync(CreateItemDTO dto);
    Task<bool> DeleteAsync(int id);
    Task<ItemDTO?> UpdateAsync(int id, UpdateItemDTO dto);
}
