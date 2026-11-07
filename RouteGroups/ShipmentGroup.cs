using Warehouse.Repositories;
using Warehouse.Models.Shipments;
using Warehouse.Models.Orders;

namespace Warehouse.RouteGroups;

public static class ShipmentsGroup
{
    public static RouteGroupBuilder MapShipmentsGroup(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/api/v1/shipments");

        group.MapGetAll<Shipment>("/");
        group.MapGetById<Shipment>("/{id}");
        group.MapGetSubResource<Shipment, Order>("/{id}/orders", id => order => order.ShipToClientId == id);
        group.MapGetSubResource<Shipment, ShipmentItem>("/{id}/items", id => shipmentItem => shipmentItem.ShipmentId == id);
        group.Post<Shipment>("/", "shipments");
        group.Delete<Shipment>("/{id}");

        group.MapPut("/{id:int}", async (int id, Shipment shipment, IRepository<Shipment> repo) =>
        {
            var existingShipment = await repo.GetByIdAsync(id);
            if (existingShipment is null) return Results.NotFound();

            existingShipment.OrderId = shipment.OrderId;
            existingShipment.Reference = shipment.Reference;
            existingShipment.ShipmentDate = shipment.ShipmentDate;
            existingShipment.ShipmentType = shipment.ShipmentType;
            existingShipment.ShipmentStatus = shipment.ShipmentStatus;
            existingShipment.CarrierName = shipment.CarrierName;
            existingShipment.ShippingMethod = shipment.ShippingMethod;
            existingShipment.PaymentType = shipment.PaymentType;
            await repo.SaveChangesAsync();

            return Results.NoContent();
        });

        group.MapPut("/{id:int}/orders", async (int id, Shipment shipment, IRepository<Shipment> repo) =>
        {
            var existingShipment = await repo.GetByIdAsync(id);
            if (existingShipment is null) return Results.NotFound();

            existingShipment.OrderId = shipment.OrderId;
            existingShipment.Reference = shipment.Reference;
            existingShipment.ShipmentDate = shipment.ShipmentDate;
            existingShipment.ShipmentType = shipment.ShipmentType;
            existingShipment.ShipmentStatus = shipment.ShipmentStatus;
            existingShipment.CarrierName = shipment.CarrierName;
            existingShipment.ShippingMethod = shipment.ShippingMethod;
            existingShipment.PaymentType = shipment.PaymentType;
            await repo.SaveChangesAsync();

            return Results.NoContent();
        });

        group.MapPut("/{id:int}/items", async (int id, Shipment shipment, IRepository<Shipment> repo) =>
        {
            var existingShipment = await repo.GetByIdAsync(id);
            if (existingShipment is null) return Results.NotFound();

            existingShipment.OrderId = shipment.OrderId;
            existingShipment.Reference = shipment.Reference;
            existingShipment.ShipmentDate = shipment.ShipmentDate;
            existingShipment.ShipmentType = shipment.ShipmentType;
            existingShipment.ShipmentStatus = shipment.ShipmentStatus;
            existingShipment.CarrierName = shipment.CarrierName;
            existingShipment.ShippingMethod = shipment.ShippingMethod;
            existingShipment.PaymentType = shipment.PaymentType;
            await repo.SaveChangesAsync();

            return Results.NoContent();
        });

        return group;
    }
}
