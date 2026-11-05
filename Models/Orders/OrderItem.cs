namespace Warehouse.Models.Orders;

using Models.Products;

[Table("OrderItem")]
public class OrderItem
{
    [Key]
    public int Id { get; set; }

    public int OrderId { get; set; }
    public Order Order { get; set; } = null!;

    public int ItemId { get; set; }
    public Item Item { get; set; } = null!;

    public int Amount { get; set; }

    public float UnitPrice { get; set; }
}
