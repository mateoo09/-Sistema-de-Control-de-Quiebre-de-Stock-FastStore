namespace FastStore.API.DTOs;

public class ProductoDto
{
    public int Id { get; set; }

    public string Nombre { get; set; } = string.Empty;

    public decimal Precio { get; set; }

    public int StockActual { get; set; }

    public int StockMinimo { get; set; }

    public string CategoriaNombre { get; set; } = string.Empty;
}