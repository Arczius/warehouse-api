using CargoHub.Dtos.Transfers;
using CargoHub.Services.Transfers;
using Microsoft.AspNetCore.Mvc;

namespace CargoHub.Controller;

[ApiController]
[Route("api/v2/Transfers")]
public class TransferController : ControllerBase
{
    private readonly ITransferService _transfer;

    public TransferController(ITransferService transfer)
    {
        _transfer = transfer;
    }

    [HttpGet]
    public async Task<ActionResult<List<TransferDTO>>> GetAll() =>
        Ok(await _transfer.GetAllAsync());

    [HttpGet("{id:int}")]
    public async Task<ActionResult<TransferDTO>> GetById(int id)
    {
        var transfer = await _transfer.GetByIdAsync(id);
        return transfer is null ? NotFound() : Ok(transfer);
    }

    [HttpPost]
    public async Task<ActionResult<TransferDTO>> Create(CreateTransferDTO dto)
    {
        var created = await _transfer.CreateAsync(dto);
        return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, UpdateTransferDTO dto) =>
        await _transfer.UpdateAsync(id, dto) is null ? NotFound() : NoContent();

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id) =>
        await _transfer.DeleteAsync(id) ? NoContent() : NotFound();
}
