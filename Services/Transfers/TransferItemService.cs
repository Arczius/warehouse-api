namespace Warehouse.Services.Transfers;

using Dtos.Transfers;
using Models.Transfers;
using Repositories;

public class TransferItemService : ITransferItemService
{
    private readonly IRepository<TransferItem> _transferItems;

    public TransferItemService(IRepository<TransferItem> transferItems)
    {
        _transferItems = transferItems;
    }

    public async Task<List<TransferItemDTO>> GetAllAsync()
    {
        var transferItems = await _transferItems.GetAllAsync();
        return transferItems.Select(ToDto).ToList();
    }

    public async Task<TransferItemDTO?> GetByIdAsync(int id)
    {
        var transferItem = await _transferItems.GetByIdAsync(id);
        return transferItem is null ? null : ToDto(transferItem);
    }

    public async Task<TransferItemDTO> CreateAsync(CreateTransferItemDTO dto)
    {
        var transferItem = new TransferItem
        {
            TransferId = dto.TransferId,
            ItemId = dto.ItemId,
            Amount = dto.Amount,
        };

        _transferItems.Add(transferItem);
        await _transferItems.SaveChangesAsync();

        return ToDto(transferItem);
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var transferItem = await _transferItems.GetByIdAsync(id);
        if (transferItem is null) return false;

        _transferItems.Delete(transferItem);
        await _transferItems.SaveChangesAsync();

        return true;
    }

    public async Task<TransferItemDTO?> UpdateAsync(int id, UpdateTransferItemDTO dto)
    {
        var transferItem = await _transferItems.GetByIdAsync(id);
        if (transferItem is null) return null;

        transferItem.TransferId = dto.TransferId;
        transferItem.ItemId = dto.ItemId;
        transferItem.Amount = dto.Amount;

        await _transferItems.SaveChangesAsync();
        return ToDto(transferItem);
    }

    private static TransferItemDTO ToDto(TransferItem transferItem) => new()
    {
        Id = transferItem.Id,
        TransferId = transferItem.TransferId,
        ItemId = transferItem.ItemId,
        Amount = transferItem.Amount,
    };
}
