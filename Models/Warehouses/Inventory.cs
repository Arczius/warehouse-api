<<<<<<< HEAD
﻿namespace Warehouse.Warehouses;
=======
﻿namespace Warehouse.Models.Warehouses;

using Models.Products;

[Table("Inventory")]
[PrimaryKey(nameof(ItemId), nameof(LocationId))]
public class Inventory
{
    public int ItemId { get; set; }
    public Item Item { get; set; } = null!;

    public int LocationId { get; set; }
    public Location Location { get; set; } = null!;

    public int QuantityOnHand { get; set; }

    public int QuantityExpected { get; set; }

    public int QuantityOrdered { get; set; }

    public int QuantityAllocated { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdateAt { get; set; }
}
>>>>>>> origin/Development
