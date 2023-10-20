using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.Repository;
    public class EspecieRepository  : GenericRepo<Especie>, IEspecie{
    protected readonly ApiContext _context;
    
    public EspecieRepository(ApiContext context) : base (context){
        _context = context;
    }

    public override async Task<IEnumerable<Especie>> GetAllAsync(){
        return await _context.Especies
            .ToListAsync();
    }

    public override async Task<Especie> GetByIdAsync(int id){
        return await _context.Especies
        .FirstOrDefaultAsync(p =>  p.Id == id);
    }

    public override async Task<(int totalRegistros, IEnumerable<Especie> registros)> GetAllAsync(int pageIndex, int pageSize, string search)
    {
        var query = _context.Especies as IQueryable<Especie>;

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
} 