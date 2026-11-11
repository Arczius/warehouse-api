namespace CargoHub.Services.Orders;

using Dtos.Orders;

public interface IOrderService
{
    Task<List<OrderDTO>> GetAllAsync();
    Task<OrderDTO?> GetByIdAsync(int id);
    Task<OrderDTO> CreateAsync(CreateOrderDTO dto);
    Task<bool> DeleteAsync(int id);
    Task<OrderDTO?> UpdateAsync(int id, UpdateOrderDTO dto);
}
