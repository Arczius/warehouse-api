namespace CargoHub.Dtos.Products;

public record ItemDTO
{
    public int Id { get; init; }
    public int ItemLineId { get; init; }
    public int ItemGroupId { get; init; }
    public int ItemTypeId { get; init; }
    public int SupplierId { get; init; }
    public string Code { get; init; } = string.Empty;
    public string Description { get; init; } = string.Empty;
    public string Barcode { get; init; } = string.Empty;
    public string ModelNumber { get; init; } = string.Empty;
    public int CommodityCode { get; init; }
    public float UnitWeight { get; init; }
    public int MinPurchaseQty { get; init; }
    public int CaseSize { get; init; }
    public string PackagingType { get; init; } = string.Empty;
    public int OrderMultiple { get; init; }
    public string SupplierSku { get; init; } = string.Empty;
    public DateTime CreatedAt { get; init; }
    public DateTime UpdatedAt { get; init; }
}

public record CreateItemDTO
{
    public int ItemLineId { get; init; }
    public int ItemGroupId { get; init; }
    public int ItemTypeId { get; init; }
    public int SupplierId { get; init; }
    public string Code { get; init; } = string.Empty;
    public string Description { get; init; } = string.Empty;
    public string Barcode { get; init; } = string.Empty;
    public string ModelNumber { get; init; } = string.Empty;
    public int CommodityCode { get; init; }
    public float UnitWeight { get; init; }
    public int MinPurchaseQty { get; init; }
    public int CaseSize { get; init; }
    public string PackagingType { get; init; } = string.Empty;
    public int OrderMultiple { get; init; }
    public string SupplierSku { get; init; } = string.Empty;
    public DateTime CreatedAt { get; init; }
    public DateTime UpdatedAt { get; init; }
}

public record UpdateItemDTO
{
    public int ItemLineId { get; init; }
    public int ItemGroupId { get; init; }
    public int ItemTypeId { get; init; }
    public int SupplierId { get; init; }
    public string Code { get; init; } = string.Empty;
    public string Description { get; init; } = string.Empty;
    public string Barcode { get; init; } = string.Empty;
    public string ModelNumber { get; init; } = string.Empty;
    public int CommodityCode { get; init; }
    public float UnitWeight { get; init; }
    public int MinPurchaseQty { get; init; }
    public int CaseSize { get; init; }
    public string PackagingType { get; init; } = string.Empty;
    public int OrderMultiple { get; init; }
    public string SupplierSku { get; init; } = string.Empty;
    public DateTime CreatedAt { get; init; }
    public DateTime UpdatedAt { get; init; }
}
