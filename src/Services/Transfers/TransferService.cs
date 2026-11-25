namespace CargoHub.Services.Transfers;

using Dtos.Transfers;
using Models.Transfers;
using Repositories;

public class TransferService : ITransferService
{
    private readonly IRepository<Transfer> _transfers;

    public TransferService(IRepository<Transfer> transfers)
    {
        _transfers = transfers;
    }

    public async Task<List<TransferDTO>> GetAllAsync()
    {
        var transfers = await _transfers.GetAllAsync();
        return transfers.Select(ToDto).ToList();
    }

    public async Task<TransferDTO?> GetByIdAsync(int id)
    {
        var transfer = await _transfers.GetByIdAsync(id);
        return transfer is null ? null : ToDto(transfer);
    }

    public async Task<TransferDTO> CreateAsync(CreateTransferDTO dto)
    {
        var transfer = new Transfer
        {
            FromLocationId = dto.FromLocationId,
            ToLocationId = dto.ToLocationId,
            Reference = dto.Reference,
            TransferStatus = dto.TransferStatus,
            CreatedAt = dto.CreatedAt,
            UpdatedAt = dto.UpdatedAt,
        };

        _transfers.Add(transfer);
        await _transfers.SaveChangesAsync();

        return ToDto(transfer);
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var transfer = await _transfers.GetByIdAsync(id);
        if (transfer is null) return false;

        _transfers.Delete(transfer);
        await _transfers.SaveChangesAsync();

        return true;
    }

    public async Task<TransferDTO?> UpdateAsync(int id, UpdateTransferDTO dto)
    {
        var transfer = await _transfers.GetByIdAsync(id);
        if (transfer is null) return null;

        transfer.FromLocationId = dto.FromLocationId;
        transfer.ToLocationId = dto.ToLocationId;
        transfer.Reference = dto.Reference;
        transfer.TransferStatus = dto.TransferStatus;
        transfer.CreatedAt = dto.CreatedAt;
        transfer.UpdatedAt = dto.UpdatedAt;

        await _transfers.SaveChangesAsync();
        return ToDto(transfer);
    }

    private static TransferDTO ToDto(Transfer transfer) => new()
    {
        Id = transfer.Id,
        FromLocationId = transfer.FromLocationId,
        ToLocationId = transfer.ToLocationId,
        Reference = transfer.Reference,
        TransferStatus = transfer.TransferStatus,
        CreatedAt = transfer.CreatedAt,
        UpdatedAt = transfer.UpdatedAt,
    };
}
