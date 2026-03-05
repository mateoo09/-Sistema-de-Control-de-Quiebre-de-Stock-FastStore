using Microsoft.EntityFrameworkCore;
using FastStore.API.Data;
using FastStore.API.DTOs;

namespace FastStore.API.Services;

public class InventoryService
{
    private readonly AppDbContext _context;

    public InventoryService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<ProductoDto>> GetAllAsync()
    {
        return await _context.Productos
            .Include(p => p.Categoria)
            .Select(p => new ProductoDto
            {
                Id = p.Id,
                Nombre = p.Nombre,
                Precio = p.Precio,
                StockActual = p.StockActual,
                StockMinimo = p.StockMinimo,
                CategoriaNombre = p.Categoria!.Nombre
            })
            .ToListAsync();
    }

    public async Task<List<ProductoDto>> GetLowStockAsync()
    {
        return await _context.Productos
            .Include(p => p.Categoria)
            .Where(p => p.StockActual < p.StockMinimo)
            .Select(p => new ProductoDto
            {
                Id = p.Id,
                Nombre = p.Nombre,
                Precio = p.Precio,
                StockActual = p.StockActual,
                StockMinimo = p.StockMinimo,
                CategoriaNombre = p.Categoria!.Nombre
            })
            .ToListAsync();
    }
}