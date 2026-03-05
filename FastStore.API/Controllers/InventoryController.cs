using Microsoft.AspNetCore.Mvc;
using FastStore.API.Services;

namespace FastStore.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class InventoryController : ControllerBase
{
    private readonly InventoryService _inventoryService;

    public InventoryController(InventoryService inventoryService)
    {
        _inventoryService = inventoryService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var productos = await _inventoryService.GetAllAsync();
        return Ok(productos);
    }

    [HttpGet("low-stock")]
    public async Task<IActionResult> GetLowStock()
    {
        var productos = await _inventoryService.GetLowStockAsync();
        return Ok(productos);
    }
}