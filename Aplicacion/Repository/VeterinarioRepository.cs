using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.Repository;
public class VeterinarioRepository : GenericRepo<Veterinario>, IVeterinario{
    protected readonly ApiContext _context;
    
    public VeterinarioRepository(ApiContext context) : base (context){
        _context = context;
    }

    public override async Task<IEnumerable<Veterinario>> GetAllAsync(){
        return await _context.Veterinarios
        .ToListAsync();
    }

    public override async Task<Veterinario> GetByIdAsync(int id){
        return await _context.Veterinarios
        .FirstOrDefaultAsync(p =>  p.Id == id);
    }

    public override async Task<(int totalRegistros, IEnumerable<Veterinario> registros)> GetAllAsync(int pageIndex, int pageSize, string search)
    {
        var query = _context.Veterinarios as IQueryable<Veterinario>;

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

    public async Task<object> veterinarioCirujano(){
        
        var Veterinarios = await (
            from v in _context.Veterinarios
            
            where v.Especialidad.Contains("Cirujano Cardiovascular")
            select new{
                Nombre = v.Nombre,
                Email = v.Email,
                Telefono = v.Telefono
            }).Distinct()
            .ToListAsync();

        return Veterinarios;
    }

    public virtual async Task<(int totalRegistros,object registros)> veterinarioCirujano(int pageIndex, int pageSize, string search)
    {
        var query = 
        (from v in _context.Veterinarios
            
            where v.Especialidad.Contains("Cirujano vascular")
            select new{
                Nombre = v.Nombre,
                Email = v.Email,
                Telefono = v.Telefono
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