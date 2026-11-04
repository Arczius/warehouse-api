namespace Warehouse.Services.Orders;

using Warehouse.Dtos.Orders;
using Warehouse.Orders;
using Warehouse.Repositories;

public class ClientService : IClientService
{
    private readonly IRepository<Client> _clients;

    public ClientService(IRepository<Client> clients)
    {
        _clients = clients;
    }

    public async Task<List<ClientDTO>> GetAllAsync()
    {
        var clients = await _clients.GetAllAsync();
        return clients.Select(ToDto).ToList();
    }

    public async Task<ClientDTO?> GetByIdAsync(int id)
    {
        var client = await _clients.GetByIdAsync(id);
        return client is null ? null : ToDto(client);
    }

    public async Task<ClientDTO> CreateAsync(CreateClientDTO dto)
    {
        var client = new Client
        {
            Name = dto.Name,
            Address = dto.Address,
            City = dto.City,
            ZipCode = dto.ZipCode,
            Province = dto.Province,
            Country = dto.Country,
            Contact = dto.Contact,
            ContactPhone = dto.ContactPhone,
            ContactEmail = dto.ContactEmail,
            CreatedAt = dto.CreatedAt,
            UpdatedAt = dto.UpdatedAt,
        };

        _clients.Add(client);
        await _clients.SaveChangesAsync();

        return ToDto(client);
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var client = await _clients.GetByIdAsync(id);
        if (client is null) return false;

        _clients.Delete(client);
        await _clients.SaveChangesAsync();

        return true;
    }

    public async Task<ClientDTO?> UpdateAsync(int id UpdateClientDTO dto)
    {
        var client = await _clients.GetByIdAsync(id);
        if (client is null) return null;

        client.Name = dto.Name;
        client.Address = dto.Address;
        client.City = dto.City;
        client.ZipCode = dto.ZipCode;
        client.Province = dto.Province;
        client.Country = dto.Country;
        client.Contact = dto.Contact;
        client.ContactPhone = dto.ContactPhone;
        client.ContactEmail = dto.ContactEmail;
        client.CreatedAt = dto.CreatedAt;
        client.UpdatedAt = dto.UpdatedAt;

        await _clients.SaveChangesAsync();
        return ToDto(client);
    }

    private static ClientDTO ToDto(Client client) => new()
    {
        Id = client.Id,
        Name = client.Name,
        Address = client.Address,
        City = client.City,
        ZipCode = client.ZipCode,
        Province = client.Province,
        Country = client.Country,
        Contact = client.Contact,
        ContactPhone = client.ContactPhone,
        ContactEmail = client.ContactEmail,
        CreatedAt = client.CreatedAt,
        UpdatedAt = client.UpdatedAt,
    };
}