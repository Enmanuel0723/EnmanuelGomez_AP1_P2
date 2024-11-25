namespace EnmanuelGomez_AP1_P2.Services;
using EnmanuelGomez_AP1_P2.DAL;
using EnmanuelGomez_AP1_P2.Model;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Expressions;

public class ArticulosService(IDbContextFactory<Contexto> DbFactory)
{


    public async Task<List<ArticulosCombos>> Listar(Expression<Func<ArticulosCombos, bool>> criterio)
    {
        var _contexto = await DbFactory.CreateDbContextAsync();
        return await _contexto.ArticulosCombos
            .Where(criterio)
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<ArticulosCombos?> Buscar(int id)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.ArticulosCombos
            .Include(c => c.ArticuloId == id)
            .FirstOrDefaultAsync(c => c.ArticuloId == id);
    }

    public async Task<ArticulosCombos?> Actualizar (int id)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.ArticulosCombos
            .Include(c => c.ArticuloId == id)
            .FirstOrDefaultAsync(c => c.ArticuloId == id);
    }


}