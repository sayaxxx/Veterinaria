using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.Repository;
public class MovimientoMedicamentoRepository : GenericRepo<MovimientoMedicamento>, IMovimientoMedicamento{
    protected readonly ApiContext _context;
    
    public MovimientoMedicamentoRepository(ApiContext context) : base (context){
        _context = context;
    }

    public override async Task<IEnumerable<MovimientoMedicamento>> GetAllAsync(){
        return await _context.MovimientoMedicamentos
            .Include(p => p.TipoMovimiento)
            .ToListAsync();
    }

    public override async Task<MovimientoMedicamento> GetByIdAsync(int id){
        return await _context.MovimientoMedicamentos
        .Include(p => p.TipoMovimiento)
        .FirstOrDefaultAsync(p =>  p.Id == id);
    }

    public override async Task<(int totalRegistros, IEnumerable<MovimientoMedicamento> registros)> GetAllAsync(int pageIndex, int pageSize, int search)
    {
        var query = _context.MovimientoMedicamentos as IQueryable<MovimientoMedicamento>;

        if (search != 0)
        {
            query = query.Where(p => p.Id == search);
        }

        query = query.OrderBy(p => p.Id);
        var totalRegistros = await query.CountAsync();
        var registros = await query
            .Include(p => p.TipoMovimiento)
            .Skip((pageIndex - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

        return (totalRegistros, registros);
    }

    public async Task<object> movimientosMedicamentoValor(){
        
        var Movimiento = await (
            from d in _context.DetalleMovimientos
            join m in _context.MovimientoMedicamentos on d.IdMovimientoMedicamentoFk equals m.Id
            
            select new{
                idMovimientoMedicamento = m.Id,
                TipoMovimiento = m.TipoMovimiento.Descripcion,
                total = d.Precio * d.Cantidad,
            }).Distinct()
            .ToListAsync();

        return Movimiento;
    }

    public virtual async Task<(int totalRegistros,object registros)> movimientosMedicamentoValor(int pageIndex, int pageSize, string search)
    {
        var query = 
            (
            from d in _context.DetalleMovimientos
            join m in _context.MovimientoMedicamentos on d.IdMovimientoMedicamentoFk equals m.Id
            
            select new{
                idMovimientoMedicamento = m.Id,
                TipoMovimiento = m.TipoMovimiento.Descripcion,
                total = d.Precio * d.Cantidad,
            }).Distinct();
        
       if(!string.IsNullOrEmpty(search))
        {
            query = query.Where(p => p.idMovimientoMedicamento.ToString().ToLower().Contains(search));
        }

        query = query.OrderBy(p => p.idMovimientoMedicamento);
        var totalRegistros = await query.CountAsync();
        var registros = await query 
            .Skip((pageIndex - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

        return (totalRegistros, registros);
    }
} 