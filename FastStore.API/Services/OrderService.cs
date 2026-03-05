using FastStore.API.Data;
using FastStore.API.DTOs;
using FastStore.API.Models;

namespace FastStore.API.Services;

public class OrderService
{
    private readonly AppDbContext _context;

    public OrderService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<(bool Success, string Message)> CreateOrderAsync(CreateOrderDto dto)
    {
        if (dto.Cantidad <= 0)
            return (false, "La cantidad debe ser mayor a cero.");

        var producto = await _context.Productos.FindAsync(dto.ProductoId);

        if (producto == null)
            return (false, "Producto no encontrado.");

        var orden = new OrdenReposicion
        {
            ProductoId = dto.ProductoId,
            Cantidad = dto.Cantidad,
            FechaSolicitud = DateTime.Now,
            Estado = "Pendiente"
        };

        _context.OrdenesReposicion.Add(orden);

        //  Actualizar stock
        producto.StockActual += dto.Cantidad;

        await _context.SaveChangesAsync();

        return (true, "Orden creada correctamente.");
    }
}