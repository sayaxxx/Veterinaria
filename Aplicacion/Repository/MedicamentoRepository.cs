using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.Repository;
public class MedicamentoRepository : GenericRepo<Medicamento>, IMedicamento{
    protected readonly ApiContext _context;
    
    public MedicamentoRepository(ApiContext context) : base (context){
        _context = context;
    }

    public override async Task<IEnumerable<Medicamento>> GetAllAsync(){
        return await _context.Medicamentos
            .Include(p => p.Laboratorio)
            .ToListAsync();
    }

    public override async Task<Medicamento> GetByIdAsync(int id){
        return await _context.Medicamentos
        .Include(p => p.Laboratorio)
        .FirstOrDefaultAsync(p =>  p.Id == id);
    }

    public override async Task<(int totalRegistros, IEnumerable<Medicamento> registros)> GetAllAsync(int pageIndex, int pageSize, string search)
    {
        var query = _context.Medicamentos as IQueryable<Medicamento>;

        if(!string.IsNullOrEmpty(search))
        {
            query = query.Where(p => p.Nombre.ToLower().Contains(search));
        }

        query = query.OrderBy(p => p.Id);
        var totalRegistros = await query.CountAsync();
        var registros = await query 
            .Include(p => p.Laboratorio)
            .Skip((pageIndex - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

        return (totalRegistros, registros);
    }

    public async Task<object> medicamentosMayor50000(){
        
        var Medicamentos = await (
            from m in _context.Medicamentos
            join l in _context.Laboratorios on m.IdLaboratorioFk equals l.Id
            where m.Precio >= 50000
            select new{
                Nombre = m.Nombre,
                CantidadDisponible = m.CantidadDisponible,
                precio = m.Precio,
                Laboratorio = l.Nombre,
            }).Distinct()
            .ToListAsync();

        return Medicamentos;
    }

    public virtual async Task<(int totalRegistros,object registros)> medicamentosMayor50000(int pageIndex, int pageSize, string search)
    {
        var query = 
            (from m in _context.Medicamentos
            join l in _context.Laboratorios on m.IdLaboratorioFk equals l.Id
            where m.Precio == 50000
            select new{
                Nombre = m.Nombre,
                CantidadDisponible = m.CantidadDisponible,
                precio = m.Precio,
                Laboratorio = l.Nombre,
            }).Distinct();
        
        if(!string.IsNullOrEmpty(search))
        {
            query = query.Where(p => p.Nombre.ToLower().Contains(search));
        }

        query = query.OrderBy(p => p.Nombre);
        var totalRegistros = await query.CountAsync();
        var registros = await query 
            .Skip((pageIndex - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

        return (totalRegistros, registros);
    }
} 