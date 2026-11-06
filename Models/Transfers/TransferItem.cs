namespace Warehouse.Models.Transfers;

using Models.Products;

[Table("TransferItem")]
public class TransferItem : IEntity
{
    [Key]
    public int Id { get; set; }

    public int TransferId { get; set; }
    public Transfer Transfer { get; set; } = null!;

    public int ItemId { get; set; }
    public Item Item { get; set; } = null!;

    public int Amount { get; set; }
}
