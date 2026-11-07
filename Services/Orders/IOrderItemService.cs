namespace CargoHub.Services.Orders;

using Dtos.Orders;

public interface IOrderItemService
{
    Task<List<OrderItemDTO>> GetAllAsync();
    Task<OrderItemDTO?> GetByIdAsync(int id);
    Task<OrderItemDTO> CreateAsync(CreateOrderItemDTO dto);
    Task<bool> DeleteAsync(int id);
    Task<OrderItemDTO?> UpdateAsync(int id, UpdateOrderItemDTO dto);
}
