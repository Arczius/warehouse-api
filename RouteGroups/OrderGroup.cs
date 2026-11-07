using Warehouse.Repositories;
using Warehouse.Models.Orders;
using Warehouse.Models.Products;

namespace Warehouse.RouteGroups;

public static class OrderGroup
{
    public static RouteGroupBuilder MapOrderGroup(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/api/v1/orders");

        group.MapGetAll<Order>("/");
        group.MapGetById<Order>("/{id}");
        group.MapGetSubResource<Order, OrderItem>("/{id}/items", id => orderitem => orderitem.OrderId == id);
        group.Post<Order>("/", "orders");
        group.Delete<Order>("/{id}");

        group.MapPut("/{id:int}", async (int id, Order order, IRepository<Order> repo) =>
        {
            var existingOrder = await repo.GetByIdAsync(id);
            if (existingOrder is null) return Results.NotFound();

            existingOrder.ClientId = order.ClientId;
            existingOrder.WarehouseId = order.WarehouseId;
            existingOrder.ShipToClientId = order.ShipToClientId;
            existingOrder.BillToClientId = order.BillToClientId;
            existingOrder.OrderDate = order.OrderDate;
            existingOrder.RequestDate = order.RequestDate;
            existingOrder.Reference = order.Reference;
            existingOrder.OrderNumber = order.OrderNumber;
            existingOrder.OrderStatus = order.OrderStatus;
            existingOrder.ShippingNotes = order.ShippingNotes;
            await repo.SaveChangesAsync();

            return Results.NoContent();
        });

        group.MapPut("/{id}/items", async (int id, Order order, IRepository<Order> repo) =>
        {
            var existingOrder = await repo.GetByIdAsync(id);
            if (existingOrder is null) return Results.NotFound();

            existingOrder.ClientId = order.ClientId;
            existingOrder.WarehouseId = order.WarehouseId;
            existingOrder.ShipToClientId = order.ShipToClientId;
            existingOrder.BillToClientId = order.BillToClientId;
            existingOrder.OrderDate = order.OrderDate;
            existingOrder.RequestDate = order.RequestDate;
            existingOrder.Reference = order.Reference;
            existingOrder.OrderNumber = order.OrderNumber;
            existingOrder.OrderStatus = order.OrderStatus;
            existingOrder.ShippingNotes = order.ShippingNotes;
            await repo.SaveChangesAsync();

            return Results.NoContent();
        });

        return group;
    }
}

