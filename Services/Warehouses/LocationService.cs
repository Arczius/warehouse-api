namespace Warehouse.Services.Warehouses;

using Dtos.Warehouses;
using Models.Warehouses;
using Repositories;

public class LocationService : ILocationService
{
    private readonly IRepository<Location> _locations;

    public LocationService(IRepository<Location> locations)
    {
        _locations = locations;
    }

    public async Task<List<LocationDTO>> GetAllAsync()
    {
        var locations = await _locations.GetAllAsync();
        return locations.Select(ToDto).ToList();
    }

    public async Task<LocationDTO?> GetByIdAsync(int id)
    {
        var location = await _locations.GetByIdAsync(id);
        return location is null ? null : ToDto(location);
    }

    public async Task<LocationDTO> CreateAsync(CreateLocationDTO dto)
    {
        var location = new Location
        {
            WarehouseId = dto.WarehouseId,
            Code = dto.Code,
            Name = dto.Name,
            CreatedAt = dto.CreatedAt,
            UpdatedAt = dto.UpdatedAt,
        };

        _locations.Add(location);
        await _locations.SaveChangesAsync();

        return ToDto(location);
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var location = await _locations.GetByIdAsync(id);
        if (location is null) return false;

        _locations.Delete(location);
        await _locations.SaveChangesAsync();

        return true;
    }

    public async Task<LocationDTO?> UpdateAsync(int id, UpdateLocationDTO dto)
    {
        var location = await _locations.GetByIdAsync(id);
        if (location is null) return null;

        location.WarehouseId = dto.WarehouseId;
        location.Code = dto.Code;
        location.Name = dto.Name;
        location.CreatedAt = dto.CreatedAt;
        location.UpdatedAt = dto.UpdatedAt;

        await _locations.SaveChangesAsync();
        return ToDto(location);
    }

    private static LocationDTO ToDto(Location location) => new()
    {
        Id = location.Id,
        WarehouseId = location.WarehouseId,
        Code = location.Code,
        Name = location.Name,
        CreatedAt = location.CreatedAt,
        UpdatedAt = location.UpdatedAt,
    };
}
