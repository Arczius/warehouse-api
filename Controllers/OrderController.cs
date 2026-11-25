using CargoHub.Dtos.Orders;
using CargoHub.Services.Orders;
using Microsoft.AspNetCore.Mvc;

namespace CargoHub.Controller;

[ApiController]
[Route("api/v2/Orders")]
public class OrderController : ControllerBase
{
    private readonly IOrderService _order;

    public OrderController(IOrderService order)
    {
        _order = order;
    }

    [HttpGet]
    public async Task<ActionResult<List<OrderDTO>>> GetAll() =>
        Ok(await _order.GetAllAsync());

    [HttpGet("{id:int}")]
    public async Task<ActionResult<OrderDTO>> GetById(int id)
    {
        var order = await _order.GetByIdAsync(id);
        return order is null ? NotFound() : Ok(order);
    }

    [HttpPost]
    public async Task<ActionResult<OrderDTO>> Create(CreateOrderDTO dto)
    {
        var created = await _order.CreateAsync(dto);
        return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, UpdateOrderDTO dto) =>
        await _order.UpdateAsync(id, dto) is null ? NotFound() : NoContent();

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id) =>
        await _order.DeleteAsync(id) ? NoContent() : NotFound();
}
