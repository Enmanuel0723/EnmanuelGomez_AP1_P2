
using EnmanuelGomez_AP1_P2.Model;
using Microsoft.EntityFrameworkCore;

namespace EnmanuelGomez_AP1_P2.DAL;

public class Contexto : DbContext
{
    public Contexto(DbContextOptions<Contexto> options) : base(options) { }

    public DbSet<Combos> Combos { get; set; }

    public DbSet<CombosDetalles> CombosDetalles { get; set; }

    public DbSet<ArticulosCombos> ArticulosCombos { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ArticulosCombos>().HasData(new List<ArticulosCombos>()
        {
            new ArticulosCombos() {ArticuloId = 1, Descripcion = "Monitor", Costo = 700, Precio = 1400, Existencia = 50},
            new ArticulosCombos() { ArticuloId = 2, Descripcion = "Mouse", Costo = 120, Precio = 500, Existencia = 100},
            new ArticulosCombos() { ArticuloId = 3, Descripcion = "Teclado", Costo = 300, Precio = 1500, Existencia = 70},
            new ArticulosCombos() {ArticuloId = 4, Descripcion = "CPU", Costo = 700, Precio = 1700, Existencia = 50},
            new ArticulosCombos() {ArticuloId = 5, Descripcion = "Memoria Ram", Costo = 350, Precio = 1300, Existencia = 40 }

        });
        base.OnModelCreating(modelBuilder);
    }
}