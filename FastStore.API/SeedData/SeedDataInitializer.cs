using System.Text.Json;
using FastStore.API.Data;
using FastStore.API.Models;

namespace FastStore.API.SeedData;

public static class SeedDataInitializer
{
    public static async Task InitializeAsync(AppDbContext context)
    {
        if (context.Productos.Any())
            return; // Ya hay datos, no volver a insertar

        var filePath = Path.Combine(Directory.GetCurrentDirectory(), "SeedData", "productos.json");

        if (!File.Exists(filePath))
            return;

        var jsonData = await File.ReadAllTextAsync(filePath);

        var productosJson = JsonSerializer.Deserialize<List<ProductoJson>>(jsonData);

        if (productosJson == null)
            return;

        foreach (var item in productosJson)
        {
            var categoria = context.Categorias
                .FirstOrDefault(c => c.Nombre == item.CategoriaNombre);

            if (categoria == null)
            {
                categoria = new Categoria
                {
                    Nombre = item.CategoriaNombre
                };

                context.Categorias.Add(categoria);
                await context.SaveChangesAsync();
            }

            var producto = new Producto
            {
                Nombre = item.Nombre,
                Precio = item.Precio,
                StockActual = item.StockActual,
                StockMinimo = item.StockMinimo,
                CategoriaId = categoria.Id
            };

            context.Productos.Add(producto);
        }

        await context.SaveChangesAsync();
    }

    private class ProductoJson
    {
        public string Nombre { get; set; } = string.Empty;
        public decimal Precio { get; set; }
        public int StockActual { get; set; }
        public int StockMinimo { get; set; }
        public string CategoriaNombre { get; set; } = string.Empty;
    }
}