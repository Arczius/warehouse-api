using CargoHub.Dtos.Products;
using CargoHub.Services.Products;
using Microsoft.AspNetCore.Mvc;

namespace CargoHub.Controller;

[ApiController]
[Route("api/v2/ItemLines")]
public class ItemLineController : ControllerBase
{
    private readonly IItemLineService _itemLine;

    public ItemLineController(IItemLineService itemLine)
    {
        _itemLine = itemLine;
    }

    [HttpGet]
    public async Task<ActionResult<List<ItemLineDTO>>> GetAll() =>
        Ok(await _itemLine.GetAllAsync());

    [HttpGet("{id:int}")]
    public async Task<ActionResult<ItemLineDTO>> GetById(int id)
    {
        var itemLine = await _itemLine.GetByIdAsync(id);
        return itemLine is null ? NotFound() : Ok(itemLine);
    }

    [HttpPost]
    public async Task<ActionResult<ItemLineDTO>> Create(CreateItemLineDTO dto)
    {
        var created = await _itemLine.CreateAsync(dto);
        return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, UpdateItemLineDTO dto) =>
        await _itemLine.UpdateAsync(id, dto) is null ? NotFound() : NoContent();

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id) =>
        await _itemLine.DeleteAsync(id) ? NoContent() : NotFound();
}
