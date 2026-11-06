<<<<<<< HEAD
﻿namespace Warehouse.Suppliers;
=======
﻿namespace Warehouse.Models.Suppliers;

[Table("Supplier")]
public class Supplier : IEntity
{
    [Key]
    public int Id { get; set; }

    [Required]
    public string Code { get; set; } = null!;

    [Required]
    public string Name { get; set; } = null!;

    [Required]
    public string Address { get; set; } = null!;

    [Required]
    public string City { get; set; } = null!;

    [Required]
    public string ZipCode { get; set; } = null!;

    [Required]
    public string Province { get; set; } = null!;

    [Required]
    public string Country { get; set; } = null!;

    [Required]
    public string ContactName { get; set; } = null!;

    [Required]
    public string ContactPhone { get; set; } = null!;

    [Required]
    public string Reference { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }
}
>>>>>>> origin/Development
