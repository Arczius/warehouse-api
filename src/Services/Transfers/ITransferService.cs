namespace CargoHub.Services.Transfers;

using Dtos.Transfers;

public interface ITransferService
{
    Task<List<TransferDTO>> GetAllAsync();
    Task<TransferDTO?> GetByIdAsync(int id);
    Task<TransferDTO> CreateAsync(CreateTransferDTO dto);
    Task<bool> DeleteAsync(int id);
    Task<TransferDTO?> UpdateAsync(int id, UpdateTransferDTO dto);
}
