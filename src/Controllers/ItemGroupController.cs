using CargoHub.Dtos.Products;
using CargoHub.Services.Products;
using Microsoft.AspNetCore.Mvc;

namespace CargoHub.Controller;

[ApiController]
[Route("api/v2/ItemGroups")]
public class ItemGroupController : ControllerBase
{
    private readonly IItemGroupService _itemGroup;

    public ItemGroupController(IItemGroupService itemGroup)
    {
        _itemGroup = itemGroup;
    }

    [HttpGet]
    public async Task<ActionResult<List<ItemGroupDtos>>> GetAll() =>
        Ok(await _itemGroup.GetAllAsync());

    [HttpGet("{id:int}")]
    public async Task<ActionResult<ItemGroupDtos>> GetById(int id)
    {
        var itemGroup = await _itemGroup.GetByIdAsync(id);
        return itemGroup is null ? NotFound() : Ok(itemGroup);
    }

    [HttpPost]
    public async Task<ActionResult<ItemGroupDtos>> Create(CreateItemGroupDtos dto)
    {
        var created = await _itemGroup.CreateAsync(dto);
        return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, UpdateItemGroupDtos dto) =>
        await _itemGroup.UpdateAsync(id, dto) is null ? NotFound() : NoContent();

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id) =>
        await _itemGroup.DeleteAsync(id) ? NoContent() : NotFound();
}
