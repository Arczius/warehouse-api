namespace CargoHub.Services.Warehouses;

using Dtos.Warehouses;
using Models.Warehouses;
using Repositories;

public class WarehouseService : IWarehouseService
{
    private readonly IRepository<Warehouse> _warehouses;

    public WarehouseService(IRepository<Warehouse> warehouses)
    {
        _warehouses = warehouses;
    }

    public async Task<List<WarehouseDTO>> GetAllAsync()
    {
        var warehouses = await _warehouses.GetAllAsync();
        return warehouses.Select(ToDto).ToList();
    }

    public async Task<WarehouseDTO?> GetByIdAsync(int id)
    {
        var warehouse = await _warehouses.GetByIdAsync(id);
        return warehouse is null ? null : ToDto(warehouse);
    }

    public async Task<WarehouseDTO> CreateAsync(CreateWarehouseDTO dto)
    {
        var warehouse = new Warehouse
        {
            Code = dto.Code,
            Name = dto.Name,
            Address = dto.Address,
            ZipCode = dto.ZipCode,
            Province = dto.Province,
            Country = dto.Country,
            ContactName = dto.ContactName,
            ContactPhone = dto.ContactPhone,
            ContactEmail = dto.ContactEmail,
            CreatedAt = dto.CreatedAt,
            UpdatedAt = dto.UpdatedAt,
        };

        _warehouses.Add(warehouse);
        await _warehouses.SaveChangesAsync();

        return ToDto(warehouse);
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var warehouse = await _warehouses.GetByIdAsync(id);
        if (warehouse is null) return false;

        _warehouses.Delete(warehouse);
        await _warehouses.SaveChangesAsync();

        return true;
    }

    public async Task<WarehouseDTO?> UpdateAsync(int id, UpdateWarehouseDTO dto)
    {
        var warehouse = await _warehouses.GetByIdAsync(id);
        if (warehouse is null) return null;

        warehouse.Code = dto.Code;
        warehouse.Name = dto.Name;
        warehouse.Address = dto.Address;
        warehouse.ZipCode = dto.ZipCode;
        warehouse.Province = dto.Province;
        warehouse.Country = dto.Country;
        warehouse.ContactName = dto.ContactName;
        warehouse.ContactPhone = dto.ContactPhone;
        warehouse.ContactEmail = dto.ContactEmail;
        warehouse.CreatedAt = dto.CreatedAt;
        warehouse.UpdatedAt = dto.UpdatedAt;

        await _warehouses.SaveChangesAsync();
        return ToDto(warehouse);
    }

    private static WarehouseDTO ToDto(Warehouse warehouse) => new()
    {
        Id = warehouse.Id,
        Code = warehouse.Code,
        Name = warehouse.Name,
        Address = warehouse.Address,
        ZipCode = warehouse.ZipCode,
        Province = warehouse.Province,
        Country = warehouse.Country,
        ContactName = warehouse.ContactName,
        ContactPhone = warehouse.ContactPhone,
        ContactEmail = warehouse.ContactEmail,
        CreatedAt = warehouse.CreatedAt,
        UpdatedAt = warehouse.UpdatedAt,
    };
}
