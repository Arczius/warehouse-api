namespace CargoHub.Models.Shipments;

using Models.Products;

[Table("ShipmentItem")]
public class ShipmentItem : IEntity
{
    [Key]
    public int Id { get; set; }

    public int ShipmentId { get; set; }
    public Shipment Shipment { get; set; } = null!;

    public int ItemId { get; set; }
    public Item Item { get; set; } = null!;

    public int Amount { get; set; }
}
