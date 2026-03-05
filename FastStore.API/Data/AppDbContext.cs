using Microsoft.EntityFrameworkCore;
using FastStore.API.Models;

namespace FastStore.API.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Categoria> Categorias => Set<Categoria>();
    public DbSet<Producto> Productos => Set<Producto>();
    public DbSet<OrdenReposicion> OrdenesReposicion => Set<OrdenReposicion>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Producto>()
            .Property(p => p.Precio)
            .HasPrecision(18, 2);

        modelBuilder.Entity<OrdenReposicion>()
            .Property(o => o.Estado)
            .HasDefaultValue("Pendiente");
    }
}