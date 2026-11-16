namespace CargoHub.Services.Suppliers;

using Dtos.Suppliers;

public interface ISupplierService
{
    Task<List<SupplierDTO>> GetAllAsync();
    Task<SupplierDTO?> GetByIdAsync(int id);
    Task<SupplierDTO> CreateAsync(CreateSupplierDTO dto);
    Task<bool> DeleteAsync(int id);
    Task<SupplierDTO?> UpdateAsync(int id, UpdateSupplierDTO dto);
}
