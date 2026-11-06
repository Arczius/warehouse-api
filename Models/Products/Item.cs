namespace Warehouse.Models.Products;

using System.Diagnostics.Contracts;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using Models.Suppliers;

[Table("Item")]
public class Item : IEntity
{
    [Key]
    public int Id { get; set; }

    public int ItemLineId { get; set; }
    public ItemLine ItemLine { get; set; } = null!;

    public int ItemGroupId { get; set; }
    public ItemGroup ItemGroup { get; set; } = null!;

    public int ItemTypeId { get; set; }
    public ItemType ItemType { get; set; } = null!;

    public int SupplierId { get; set; }
    public Supplier Supplier { get; set; } = null!;

    [Required]
    public string Code { get; set; } = null!;

    [Required]
    public string Description { get; set; } = null!;

    [Required]
    public string Barcode { get; set; } = null!;

    [Required]
    public string ModelNumber { get; set; } = null!;

    [Required]
    public string CommodityCode { get; set; } = null!;

    public float UnitWeight { get; set; }

    public int MinPurchaseQty { get; set; }

    public int CaseSize { get; set; }

    [Required]
    public string PackagingType { get; set; } = null!;

    public int OrderMultiple { get; set; }

    [Required]
    public string SupplierSku { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }
}
