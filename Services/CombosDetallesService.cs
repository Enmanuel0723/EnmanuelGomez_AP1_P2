using EnmanuelGomez_AP1_P2.DAL;
using EnmanuelGomez_AP1_P2.Model;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace EnmanuelGomez_AP1_P2.Services;

public class CombosDetallesService(IDbContextFactory<Contexto> DbFactory)
{
    public async Task<bool> Existe(int DetalleId)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.CombosDetalles.AllAsync(c => c.DetalleId == DetalleId);

    }

    public async Task<bool> Guardar(CombosDetalles detalle)
    {
        if (!await Existe(detalle.DetalleId))
        {
            return await Insertar(detalle);
        }
        else
        {
            return await Modificar(detalle);
        }
    }

    public async Task<bool> Insertar(CombosDetalles detalle)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        contexto.CombosDetalles.Add(detalle);
        return await contexto.SaveChangesAsync() > 0;


    }

    public async Task<bool> Modificar(CombosDetalles detalle)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        contexto.Update(detalle);
        return await contexto.SaveChangesAsync() > 0;
    }

    public async Task<bool> Eliminar(int id)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        var Detalle = contexto.CombosDetalles.Find(id);
        contexto.CombosDetalles.Remove(Detalle);
        var cantidad = await contexto.SaveChangesAsync();
        return cantidad > 0;
    }

    public async Task<CombosDetalles?> Buscar(int id)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.CombosDetalles.Include(c => c.DetalleId == id)
            .FirstOrDefaultAsync(c => c.DetalleId == id);
    }

    public async Task<List<CombosDetalles>> Listar(Expression<Func<CombosDetalles, bool>> criterio)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.CombosDetalles.Include(a => a.DetalleId)
           .Where(criterio)
           .AsNoTracking()
           .ToListAsync();
    }
}
