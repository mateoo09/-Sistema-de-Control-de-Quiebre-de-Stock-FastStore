using Microsoft.AspNetCore.Mvc;
using FastStore.API.Services;
using FastStore.API.DTOs;

namespace FastStore.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OrdersController : ControllerBase
{
    private readonly OrderService _orderService;

    public OrdersController(OrderService orderService)
    {
        _orderService = orderService;
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateOrderDto dto)
    {
        var result = await _orderService.CreateOrderAsync(dto);

        if (!result.Success)
            return BadRequest(result.Message);

        return Ok(new { message = result.Message });
    }
}