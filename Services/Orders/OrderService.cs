namespace CargoHub.Services.Orders;

using Dtos.Orders;
using Models.Orders;
using Repositories;

public class OrderService : IOrderService
{
    private readonly IRepository<Order> _orders;
    public OrderService(IRepository<Order> orders)
    {
        _orders = orders;
    }

    public async Task<List<OrderDTO>> GetAllAsync()
    {
        var orders = await _orders.GetAllAsync();
        return orders.Select(ToDto).ToList();
    }

    public async Task<OrderDTO?> GetByIdAsync(int id)
    {
        var order = await _orders.GetByIdAsync(id);
        return order is null ? null : ToDto(order);
    }

    public async Task<OrderDTO> CreateAsync(CreateOrderDTO dto)
    {
        var order = new Order
        {
            ClientId = dto.ClientId,
            WarehouseId = dto.WarehouseId,
            ShipToClientId = dto.ShipToClientId,
            BillToClientId = dto.BillToClientId,
            OrderDate = dto.OrderDate,
            RequestDate = dto.RequestDate,
            Reference = dto.Reference,
            OrderNumber = dto.OrderNumber,
            OrderStatus = dto.OrderStatus,
            ShippingNotes = dto.ShippingNotes,
            CreatedAt = dto.CreatedAt,
            UpdatedAt = dto.UpdatedAt,
        };

        _orders.Add(order);
        await _orders.SaveChangesAsync();

        return ToDto(order);
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var order = await _orders.GetByIdAsync(id);
        if (order is null) return false;

        _orders.Delete(order);
        await _orders.SaveChangesAsync();

        return true;
    }

    public async Task<OrderDTO?> UpdateAsync(int id, UpdateOrderDTO dto)
    {
        var order = await _orders.GetByIdAsync(id);
        if (order is null) return null;

        order.ClientId = dto.ClientId;
        order.WarehouseId = dto.WarehouseId;
        order.ShipToClientId = dto.ShipToClientId;
        order.BillToClientId = dto.BillToClientId;
        order.OrderDate = dto.OrderDate;
        order.RequestDate = dto.RequestDate;
        order.Reference = dto.Reference;
        order.OrderNumber = dto.OrderNumber;
        order.OrderStatus = dto.OrderStatus;
        order.ShippingNotes = dto.ShippingNotes;
        order.CreatedAt = dto.CreatedAt;
        order.UpdatedAt = dto.UpdatedAt;

        await _orders.SaveChangesAsync();
        return ToDto(order);
    }

    private static OrderDTO ToDto(Order order) => new()
    {
        Id = order.Id,
        ClientId = order.ClientId,
        WarehouseId = order.WarehouseId,
        ShipToClientId = order.ShipToClientId,
        BillToClientId = order.BillToClientId,
        OrderDate = order.OrderDate,
        RequestDate = order.RequestDate,
        Reference = order.Reference,
        OrderNumber = order.OrderNumber,
        OrderStatus = order.OrderStatus,
        ShippingNotes = order.ShippingNotes,
        CreatedAt = order.CreatedAt,
        UpdatedAt = order.UpdatedAt,
    };
}
