using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.Repository;
public class CitaRepository : GenericRepo<Cita>, ICita{
    protected readonly ApiContext _context;
    
    public CitaRepository(ApiContext context) : base (context){
        _context = context;
    }

    public override async Task<IEnumerable<Cita>> GetAllAsync(){
        return await _context.Citas
            .Include(c => c.Mascota)
            .ToListAsync();
    }

    public override async Task<Cita> GetByIdAsync(int id){
        return await _context.Citas
        .Include(c => c.Mascota)
        .FirstOrDefaultAsync(p =>  p.Id == id);
    }

    public override async Task<(int totalRegistros, IEnumerable<Cita> registros)> GetAllAsync(int pageIndex, int pageSize, int search){
        var query = _context.Citas as IQueryable<Cita>;

        if (search != 0)
        {
            query = query.Where(p => p.IdVeterinarioFk == search);
        }

        query = query.OrderBy(p => p.Id);
        var totalRegistros = await query.CountAsync();
        var registros = await query
            .Include(p => p.Mascota)
            .Skip((pageIndex - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

        return (totalRegistros, registros);
    }

} 