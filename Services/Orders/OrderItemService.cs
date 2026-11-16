namespace CargoHub.Services.Orders;

using Dtos.Orders;
using Models.Orders;
using Repositories;

public class OrderItemService : IOrderItemService
{
    private readonly IRepository<OrderItem> _orderItems;

    public OrderItemService(IRepository<OrderItem> orderItems)
    {
        _orderItems = orderItems;
    }

    public async Task<List<OrderItemDTO>> GetAllAsync()
    {
        var orderItems = await _orderItems.GetAllAsync();
        return orderItems.Select(ToDto).ToList();
    }

    public async Task<OrderItemDTO?> GetByIdAsync(int id)
    {
        var orderItem = await _orderItems.GetByIdAsync(id);
        return orderItem is null ? null : ToDto(orderItem);
    }

    public async Task<OrderItemDTO> CreateAsync(CreateOrderItemDTO dto)
    {
        var orderItem = new OrderItem
        {
            OrderId = dto.OrderId,
            ItemId = dto.ItemId,
            Amount = dto.Amount,
            UnitPrice = dto.UnitPrice,
        };

        _orderItems.Add(orderItem);
        await _orderItems.SaveChangesAsync();

        return ToDto(orderItem);
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var orderItem = await _orderItems.GetByIdAsync(id);
        if (orderItem is null) return false;

        _orderItems.Delete(orderItem);
        await _orderItems.SaveChangesAsync();

        return true;
    }

    public async Task<OrderItemDTO?> UpdateAsync(int id, UpdateOrderItemDTO dto)
    {
        var orderItem = await _orderItems.GetByIdAsync(id);
        if (orderItem is null) return null;

        orderItem.OrderId = dto.OrderId;
        orderItem.ItemId = dto.ItemId;
        orderItem.Amount = dto.Amount;
        orderItem.UnitPrice = dto.UnitPrice;

        await _orderItems.SaveChangesAsync();
        return ToDto(orderItem);
    }

    private static OrderItemDTO ToDto(OrderItem orderItem) => new()
    {
        Id = orderItem.Id,
        OrderId = orderItem.OrderId,
        ItemId = orderItem.ItemId,
        Amount = orderItem.Amount,
        UnitPrice = orderItem.UnitPrice,
    };
}
