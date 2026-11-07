using Warehouse.Repositories;
using Warehouse.Models.Transfers;
using Warehouse.Models.Products;

namespace Warehouse.RouteGroups;

public static class TransferGroup
{
    public static RouteGroupBuilder MapTransferGroup(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/api/v1/transfers");

        group.MapGetAll<Transfer>("/");
        group.MapGetById<Transfer>("/{id}");
        group.MapGetSubResource<Transfer, TransferItem>("/{id}/items", id => transferitem => transferitem.TransferId == id);
        group.Post<Transfer>("/", "transfers");
        group.Delete<Transfer>("/{id}");

        group.MapPut("/{id:int}", async (int id, Transfer transfer, IRepository<Transfer> repo) =>
        {
            var existingTransfer = await repo.GetByIdAsync(id);
            if (existingTransfer is null) return Results.NotFound();

            existingTransfer.FromLocationId = transfer.FromLocationId;
            existingTransfer.ToLocationId = transfer.ToLocationId;
            existingTransfer.Reference = transfer.Reference;
            existingTransfer.TransferStatus = transfer.TransferStatus;
            await repo.SaveChangesAsync();

            return Results.NoContent();
        });

        group.MapPut("/{id}/commit", async (int id, Transfer transfer, IRepository<Transfer> repo) =>
        {
            var existingTransfer = await repo.GetByIdAsync(id);
            if (existingTransfer is null) return Results.NotFound();

            existingTransfer.FromLocationId = transfer.FromLocationId;
            existingTransfer.ToLocationId = transfer.ToLocationId;
            existingTransfer.Reference = transfer.Reference;
            existingTransfer.TransferStatus = transfer.TransferStatus;
            await repo.SaveChangesAsync();

            return Results.NoContent();
        });

        return group;
    }
}

