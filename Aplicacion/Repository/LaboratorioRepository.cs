using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.Repository;
    public class LaboratorioRepository  : GenericRepo<Laboratorio>, ILaboratorio
{
    protected readonly ApiContext _context;
    
    public LaboratorioRepository(ApiContext context) : base (context){
        _context = context;
    }

    public override async Task<IEnumerable<Laboratorio>> GetAllAsync(){
        return await _context.Laboratorios
            .ToListAsync();
    }

    public override async Task<Laboratorio> GetByIdAsync(int id){
        return await _context.Laboratorios
        .FirstOrDefaultAsync(p =>  p.Id == id);
    }
    public override async Task<(int totalRegistros, IEnumerable<Laboratorio> registros)> GetAllAsync(int pageIndex, int pageSize, string search)
    {
        var query = _context.Laboratorios as IQueryable<Laboratorio>;

        if(!string.IsNullOrEmpty(search))
        {
            query = query.Where(p => p.Nombre.ToLower().Contains(search));
        }

        query = query.OrderBy(p => p.Id);
        var totalRegistros = await query.CountAsync();
        var registros = await query 
            .Skip((pageIndex - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

        return (totalRegistros, registros);
    }
    public async Task<object> listarMedicamentosGenfar(){
        
        var Laboratorios = await (
            from m in _context.Medicamentos
            join l in  _context.Laboratorios on m.IdLaboratorioFk equals l.Id
            where l.Nombre.Contains("Genfar")
            select new{
                Nombre = m.Nombre,
                CantidadDisponible = m.CantidadDisponible,
                precio = m.Precio,
            }).Distinct()
            .ToListAsync();

        return Laboratorios;
    }
    public virtual async Task<(int totalRegistros,object registros)> listarMedicamentosGenfar(int pageIndex, int pageSize, string search)
    {
        var query = 
            (from l in _context.Laboratorios
            where l.Nombre.Contains("Genfar")
            select new{
                Nombre = l.Nombre,
                Direccion = l.Direccion,
                Telefono = l.Telefono
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