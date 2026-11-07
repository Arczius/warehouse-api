using Warehouse.Repositories;
using Warehouse.Models.Suppliers;
using Warehouse.Models.Products;

namespace Warehouse.RouteGroups;

public static class SupplierGroup
{
    public static RouteGroupBuilder MapSupplierGroup(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/api/v1/suppliers");

        group.MapGetAll<Supplier>("/");
        group.MapGetById<Supplier>("/{id}");
        group.MapGetSubResource<Supplier, Item>("/{id}/items", id => item => item.SupplierId == id);
        group.Post<Supplier>("/", "suppliers");
        group.Delete<Supplier>("/{id}");

        group.MapPut("/{id:int}", async (int id, Supplier supplier, IRepository<Supplier> repo) =>
        {
            var existingSupplier = await repo.GetByIdAsync(id);
            if (existingSupplier is null) return Results.NotFound();

            existingSupplier.Code = supplier.Code;
            existingSupplier.Name = supplier.Name;
            existingSupplier.Address = supplier.Address;
            existingSupplier.City = supplier.City;
            existingSupplier.ZipCode = supplier.ZipCode;
            existingSupplier.Province = supplier.Province;
            existingSupplier.Country = supplier.Country;
            existingSupplier.ContactName = supplier.ContactName;
            existingSupplier.ContactPhone = supplier.ContactPhone;
            existingSupplier.Reference = supplier.Reference;
            await repo.SaveChangesAsync();

            return Results.NoContent();
        });

        return group;
    }
}

