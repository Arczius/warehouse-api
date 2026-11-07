namespace CargoHub.Services.Products;

using Dtos.Products;

public interface IItemTypeService
{
    Task<List<ItemTypeDTO>> GetAllAsync();
    Task<ItemTypeDTO?> GetByIdAsync(int id);
    Task<ItemTypeDTO> CreateAsync(CreateItemTypeDTO dto);
    Task<bool> DeleteAsync(int id);
    Task<ItemTypeDTO?> UpdateAsync(int id, UpdateItemTypeDTO dto);
}
