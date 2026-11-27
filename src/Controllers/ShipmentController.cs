using CargoHub.Dtos.Shipments;
using CargoHub.Services.Shipments;
using Microsoft.AspNetCore.Mvc;

namespace CargoHub.Controller;

[ApiController]
[Route("api/v2/Shipments")]
public class ShipmentController : ControllerBase
{
    private readonly IShipmentService _shipment;

    public ShipmentController(IShipmentService shipment)
    {
        _shipment = shipment;
    }

    [HttpGet]
    public async Task<ActionResult<List<ShipmentDTO>>> GetAll() =>
        Ok(await _shipment.GetAllAsync());

    [HttpGet("{id:int}")]
    public async Task<ActionResult<ShipmentDTO>> GetById(int id)
    {
        var shipment = await _shipment.GetByIdAsync(id);
        return shipment is null ? NotFound() : Ok(shipment);
    }

    [HttpPost]
    public async Task<ActionResult<ShipmentDTO>> Create(CreateShipmentDTO dto)
    {
        var created = await _shipment.CreateAsync(dto);
        return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, UpdateShipmentDTO dto) =>
        await _shipment.UpdateAsync(id, dto) is null ? NotFound() : NoContent();

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id) =>
        await _shipment.DeleteAsync(id) ? NoContent() : NotFound();
}
