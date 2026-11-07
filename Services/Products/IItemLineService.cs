namespace Warehouse.Services.Products;

using Dtos.Products;

public interface IItemLineService
{
    Task<List<ItemLineDTO>> GetAllAsync();
    Task<ItemLineDTO?> GetByIdAsync(int id);
    Task<ItemLineDTO> CreateAsync(CreateItemLineDTO dto);
    Task<bool> DeleteAsync(int id);
    Task<ItemLineDTO?> UpdateAsync(int id, UpdateItemLineDTO dto);
}
