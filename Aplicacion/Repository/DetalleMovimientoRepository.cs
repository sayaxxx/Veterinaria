using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.Repository;
public class DetalleMovimientoRepository : GenericRepo<DetalleMovimiento>, IDetalleMovimiento{
    protected readonly ApiContext _context;
    
    public DetalleMovimientoRepository(ApiContext context) : base (context){
        _context = context;
    }

    public override async Task<IEnumerable<DetalleMovimiento>> GetAllAsync(){
        return await _context.DetalleMovimientos
            .Include(p => p.MovimientoMedicamento)
            .Include(p => p.Medicamento)
            .ToListAsync();
    }

    public override async Task<DetalleMovimiento> GetByIdAsync(int id){
        return await _context.DetalleMovimientos
            .Include(p => p.MovimientoMedicamento)
            .Include(p => p.Medicamento)        
            .FirstOrDefaultAsync(p =>  p.Id == id);
    }

    public override async Task<(int totalRegistros, IEnumerable<DetalleMovimiento> registros)> GetAllAsync(int pageIndex, int pageSize, int search){
        var query = _context.DetalleMovimientos as IQueryable<DetalleMovimiento>;

        if (search != 0)
        {
            query = query.Where(p => p.IdMovimientoMedicamentoFk == search);
        }

        query = query.OrderBy(p => p.Id);
        var totalRegistros = await query.CountAsync();
        var registros = await query
            .Include(p => p.MovimientoMedicamento)
            .Include(p => p.Medicamento)
            .Skip((pageIndex - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

        return (totalRegistros, registros);
    }
} 