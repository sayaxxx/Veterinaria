using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.Repository;
public class ProveedorRepository : GenericRepo<Proveedor>, IProveedor{
    protected readonly ApiContext _context;
    
    public ProveedorRepository(ApiContext context) : base (context){
        _context = context;
    }

    public override async Task<IEnumerable<Proveedor>> GetAllAsync(){
        return await _context.Proveedores
            .ToListAsync();
    }

    public override async Task<Proveedor> GetByIdAsync(int id){
        return await _context.Proveedores
        .FirstOrDefaultAsync(p =>  p.Id == id);
    }
    public override async Task<(int totalRegistros, IEnumerable<Proveedor> registros)> GetAllAsync(int pageIndex, int pageSize, string search)
    {
        var query = _context.Proveedores as IQueryable<Proveedor>;

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

    public async Task<object> medicamentoProveedoresEspe(){
        var consulta = from m in _context.Medicamentos
        select new
        {
            Nombre = m.Nombre,
            proveedores = (from mp in _context.MedicamentoProveedores
                        join me in _context.Medicamentos on mp.IdMedicamentoFk equals me.Id
                        join p in _context.Proveedores on mp.IdProveedorFk equals p.Id
                        where m.Id == mp.IdMedicamentoFk
                        select new
                        {
                            NombreProveedor = p.Nombre,
                        }).ToList()
        };

        var propietariosConMascotas = await consulta.ToListAsync();
        return propietariosConMascotas;
    }

    public virtual async Task<(int totalRegistros,object registros)> medicamentoProveedoresEspe(int pageIndex, int pageSize, string search)
    {
        var query = 
        from m in _context.Medicamentos
        select new
        {
            Nombre = m.Nombre,
            proveedores = (from mp in _context.MedicamentoProveedores
                        join me in _context.Medicamentos on mp.IdMedicamentoFk equals me.Id
                        join p in _context.Proveedores on mp.IdProveedorFk equals p.Id
                        where m.Id == mp.IdMedicamentoFk
                        select new
                        {
                            NombreProveedor = p.Nombre,
                        }).ToList()
        };
        
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