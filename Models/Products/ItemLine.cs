<<<<<<< HEAD
﻿namespace Warehouse.Products;
=======
﻿namespace Warehouse.Models.Products;

[Table("ItemLine")]
public class ItemLine : IEntity
{
    [Key]
    public int Id { get; set; }

    [Required]
    public string Name { get; set; } = null!;

    [Required]
    public string Description { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }
}
>>>>>>> origin/Development
