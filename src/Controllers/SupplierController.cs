using CargoHub.Dtos.Suppliers;
using CargoHub.Services.Suppliers;
using Microsoft.AspNetCore.Mvc;

namespace CargoHub.Controller;

[ApiController]
[Route("api/v2/Suppliers")]
public class SupplierController : ControllerBase
{
    private readonly ISupplierService _supplier;

    public SupplierController(ISupplierService supplier)
    {
        _supplier = supplier;
    }

    [HttpGet]
    public async Task<ActionResult<List<SupplierDTO>>> GetAll() =>
        Ok(await _supplier.GetAllAsync());

    [HttpGet("{id:int}")]
    public async Task<ActionResult<SupplierDTO>> GetById(int id)
    {
        var supplier = await _supplier.GetByIdAsync(id);
        return supplier is null ? NotFound() : Ok(supplier);
    }

    [HttpPost]
    public async Task<ActionResult<SupplierDTO>> Create(CreateSupplierDTO dto)
    {
        var created = await _supplier.CreateAsync(dto);
        return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, UpdateSupplierDTO dto) =>
        await _supplier.UpdateAsync(id, dto) is null ? NotFound() : NoContent();

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id) =>
        await _supplier.DeleteAsync(id) ? NoContent() : NotFound();
}
