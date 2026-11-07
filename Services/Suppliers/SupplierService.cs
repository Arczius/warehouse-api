namespace Warehouse.Services.Suppliers;

using Dtos.Suppliers;
using Models.Suppliers;
using Repositories;

public class SupplierService : ISupplierService
{
    private readonly IRepository<Supplier> _suppliers;

    public SupplierService(IRepository<Supplier> suppliers)
    {
        _suppliers = suppliers;
    }

    public async Task<List<SupplierDTO>> GetAllAsync()
    {
        var suppliers = await _suppliers.GetAllAsync();
        return suppliers.Select(ToDto).ToList();
    }

    public async Task<SupplierDTO?> GetByIdAsync(int id)
    {
        var supplier = await _suppliers.GetByIdAsync(id);
        return supplier is null ? null : ToDto(supplier);
    }

    public async Task<SupplierDTO> CreateAsync(CreateSupplierDTO dto)
    {
        var supplier = new Supplier
        {
            Code = dto.Code,
            Name = dto.Name,
            Address = dto.Address,
            City = dto.City,
            ZipCode = dto.ZipCode,
            Province = dto.Province,
            Country = dto.Country,
            ContactName = dto.ContactName,
            ContactPhone = dto.ContactPhone,
            Reference = dto.Reference,
            CreatedAt = dto.CreatedAt,
            UpdatedAt = dto.UpdatedAt,
        };

        _suppliers.Add(supplier);
        await _suppliers.SaveChangesAsync();

        return ToDto(supplier);
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var supplier = await _suppliers.GetByIdAsync(id);
        if (supplier is null) return false;

        _suppliers.Delete(supplier);
        await _suppliers.SaveChangesAsync();

        return true;
    }

    public async Task<SupplierDTO?> UpdateAsync(int id, UpdateSupplierDTO dto)
    {
        var supplier = await _suppliers.GetByIdAsync(id);
        if (supplier is null) return null;

        supplier.Code = dto.Code;
        supplier.Name = dto.Name;
        supplier.Address = dto.Address;
        supplier.City = dto.City;
        supplier.ZipCode = dto.ZipCode;
        supplier.Province = dto.Province;
        supplier.Country = dto.Country;
        supplier.ContactName = dto.ContactName;
        supplier.ContactPhone = dto.ContactPhone;
        supplier.Reference = dto.Reference;
        supplier.CreatedAt = dto.CreatedAt;
        supplier.UpdatedAt = dto.UpdatedAt;

        await _suppliers.SaveChangesAsync();
        return ToDto(supplier);
    }

    private static SupplierDTO ToDto(Supplier supplier) => new()
    {
        Id = supplier.Id,
        Code = supplier.Code,
        Name = supplier.Name,
        Address = supplier.Address,
        City = supplier.City,
        ZipCode = supplier.ZipCode,
        Province = supplier.Province,
        Country = supplier.Country,
        ContactName = supplier.ContactName,
        ContactPhone = supplier.ContactPhone,
        Reference = supplier.Reference,
        CreatedAt = supplier.CreatedAt,
        UpdatedAt = supplier.UpdatedAt,
    };
}
