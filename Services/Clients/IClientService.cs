namespace CargoHub.Services.Clients;

using Dtos.Clients;

public interface IClientService
{
    Task<List<ClientDTO>> GetAllAsync();
    Task<ClientDTO?> GetByIdAsync(int id);
    Task<ClientDTO> CreateAsync(CreateClientDTO dto);
    Task<bool> DeleteAsync(int id);
    Task<ClientDTO?> UpdateAsync(int id, UpdateClientDTO dto);
}
