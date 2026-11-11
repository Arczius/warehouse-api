namespace CargoHub.Services.Transfers;

using Dtos.Transfers;

public interface ITransferItemService
{
    Task<List<TransferItemDTO>> GetAllAsync();
    Task<TransferItemDTO?> GetByIdAsync(int id);
    Task<TransferItemDTO> CreateAsync(CreateTransferItemDTO dto);
    Task<bool> DeleteAsync(int id);
    Task<TransferItemDTO?> UpdateAsync(int id, UpdateTransferItemDTO dto);
}
