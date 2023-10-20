using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.Repository;
public class TipoMovimientoRepository : GenericRepo<TipoMovimiento>, ITipoMovimiento{
    protected readonly ApiContext _context;
    
    public TipoMovimientoRepository(ApiContext context) : base (context){
        _context = context;
    }

    public override async Task<IEnumerable<TipoMovimiento>> GetAllAsync(){
        return await _context.TipoMovimientos
            .ToListAsync();
    }

    public override async Task<TipoMovimiento> GetByIdAsync(int id){
        return await _context.TipoMovimientos
        .FirstOrDefaultAsync(p =>  p.Id == id);
    }

    public override async Task<(int totalRegistros, IEnumerable<TipoMovimiento> registros)> GetAllAsync(int pageIndex, int pageSize, string search)
    {
        var query = _context.TipoMovimientos as IQueryable<TipoMovimiento>;

        if(!string.IsNullOrEmpty(search))
        {
            query = query.Where(p => p.Descripcion.ToLower().Contains(search));
        }

        query = query.OrderBy(p => p.Id);
        var totalRegistros = await query.CountAsync();
        var registros = await query 
            .Skip((pageIndex - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

        return (totalRegistros, registros);
    }
} 