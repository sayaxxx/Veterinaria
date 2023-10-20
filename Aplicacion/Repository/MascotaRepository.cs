using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.Repository;
public class MascotaRepository : GenericRepo<Mascota>, IMascota{
    protected readonly ApiContext _context;
    
    public MascotaRepository(ApiContext context) : base (context){
        _context = context;
    }

    public override async Task<IEnumerable<Mascota>> GetAllAsync(){
        return await _context.Mascotas
            .Include(p => p.Propietario)
            .ToListAsync();
    }

    public override async Task<Mascota> GetByIdAsync(int id){
        return await _context.Mascotas
        .Include(p => p.Propietario)
        .FirstOrDefaultAsync(p =>  p.Id == id);
    }

    public override async Task<(int totalRegistros, IEnumerable<Mascota> registros)> GetAllAsync(int pageIndex, int pageSize, string search)
    {
        var query = _context.Mascotas as IQueryable<Mascota>;

        if(!string.IsNullOrEmpty(search))
        {
            query = query.Where(p => p.Nombre.ToLower().Contains(search));
        }

        query = query.OrderBy(p => p.Id);
        var totalRegistros = await query.CountAsync();
        var registros = await query 
            .Include(p => p.Propietario)
            .Skip((pageIndex - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

        return (totalRegistros, registros);
    }

    public virtual async Task<object> mascotasFelinas(){
        
        var Mascotas = await (
            from m in _context.Mascotas
            join r in _context.Razas on m.IdRazaFk equals r.Id
            join p in _context.Propietarios on m.IdPropietarioFk equals p.Id
            join e in _context.Especies on r.IdEspecieFk equals e.Id
            where e.Nombre.Contains("felina")
            select new{
                Nombre = m.Nombre,
                Propietario = p.Nombre,
                FechaNacimiento = m.FechaNacimiento
            }).Distinct()
            .ToListAsync();

        return Mascotas;
    }

    public virtual async Task<(int totalRegistros,object registros)> mascotasFelinas(int pageIndex, int pageSize, string search)
    {
        var query = ( from m in _context.Mascotas
            join r in _context.Razas on m.IdRazaFk equals r.Id
            join p in _context.Propietarios on m.IdPropietarioFk equals p.Id
            join e in _context.Especies on r.IdEspecieFk equals e.Id
            where e.Nombre.Contains("felina")
            select new{
                Nombre = m.Nombre,
                Propietario = p.Nombre,
                FechaNacimiento = m.FechaNacimiento
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

    public virtual async Task<object> vacunacion2023(){
        int year = 2023; 
        DateTime primerTrimestreInicio = new DateTime(year, 1, 1); 
        DateTime primerTrimestreFin = new DateTime(year, 3, 31); 
 
        var Mascotas = await (
            from c in _context.Citas
            join m in _context.Mascotas on c.IdMascotaFk equals m.Id
            
            where c.Motivo == "Vacunación" && 
              c.Hora >= primerTrimestreInicio && c.Hora <= primerTrimestreFin

            
            select new{
                NombreMascota = m.Nombre,
                Motivo = c.Motivo,
                FechaNacimientoMascota = m.FechaNacimiento,
                FechaCita = c.Hora
            }).Distinct()
            .ToListAsync();
            Console.WriteLine(primerTrimestreInicio);
            Console.WriteLine(primerTrimestreFin);
        return Mascotas;
    }

    public virtual async Task<(int totalRegistros,object registros)> vacunacion2023(int pageIndex, int pageSize, string search)
    {
        int year = 2023; 
        DateTime primerTrimestreInicio = new DateTime(year, 1, 1); 
        DateTime primerTrimestreFin = new DateTime(year, 3, 31); 

        var query = (
            from c in _context.Citas
            join m in _context.Mascotas on c.IdMascotaFk equals m.Id
            
            where c.Motivo == "Vacunación" && 
              c.Hora >= primerTrimestreInicio && c.Hora <= primerTrimestreFin

            
            select new{
                NombreMascota = m.Nombre,
                Motivo = c.Motivo,
                FechaNacimientoMascota = m.FechaNacimiento,
                FechaCita = c.Hora
            }).Distinct();
        
        if(!string.IsNullOrEmpty(search))
        {
            query = query.Where(p => p.NombreMascota.ToLower().Contains(search));
        }

        query = query.OrderBy(p => p.NombreMascota);
        var totalRegistros = await query.CountAsync();
        var registros = await query 
            .Skip((pageIndex - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

        return (totalRegistros, registros);
    }

    public async Task<object> mascotasPorEspecie(){
        var consulta = 
        from e in _context.Especies 
        select new
        {
            NombreEspecie = e.Nombre,
            Mascotas = (from m in _context.Mascotas
                        join r in _context.Razas on m.IdRazaFk equals r.Id
                        where m.IdRazaFk == r.Id
                        where r.IdEspecieFk == e.Id
                        select new
                        {
                            NombreMascota = m.Nombre,
                            FechaNacimiento = m.FechaNacimiento,
                            Raza = r.Nombre
                        }).ToList()
        };

        var MascotaEspecie = await consulta.ToListAsync();
        return MascotaEspecie;
    }

    public virtual async Task<(int totalRegistros,object registros)> mascotasPorEspecie(int pageIndex, int pageSize, string search)
    {
        var query = 
        from e in _context.Especies 
        select new
        {
            NombreEspecie = e.Nombre,
            Mascotas = (from m in _context.Mascotas
                        join r in _context.Razas on m.IdRazaFk equals r.Id
                        where m.IdRazaFk == r.Id
                        where r.IdEspecieFk == e.Id
                        select new
                        {
                            NombreMascota = m.Nombre,
                            FechaNacimiento = m.FechaNacimiento,
                            Raza = r.Nombre
                        }).ToList()
        };
        
        if(!string.IsNullOrEmpty(search))
        {
            query = query.Where(p => p.NombreEspecie.ToLower().Contains(search));
        }

        query = query.OrderBy(p => p.NombreEspecie);
        var totalRegistros = await query.CountAsync();
        var registros = await query 
            .Skip((pageIndex - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

        return (totalRegistros, registros);
    }
    public async Task<object> mascotasAtendidasVeterinario(){
        var consulta = 
        from e in _context.Citas 
        join v in _context.Veterinarios on e.IdVeterinarioFk equals v.Id
        select new
        {
            Veterinario = v.Nombre,
            Mascotas = (from c in _context.Citas 
                        join m in _context.Mascotas on c.IdMascotaFk equals m.Id
                        where c.IdVeterinarioFk == v.Id
                        select new
                        {
                            NombreMascota = m.Nombre,
                            FechaNacimiento = m.FechaNacimiento,
                        }).ToList()
        };

        var MascotaEspecie = await consulta.ToListAsync();
        return MascotaEspecie;
    }

    public virtual async Task<(int totalRegistros,object registros)> mascotasAtendidasVeterinario(int pageIndex, int pageSize, string search){
        var query = 
        from e in _context.Citas 
        join v in _context.Veterinarios on e.IdVeterinarioFk equals v.Id
        select new
        {
            Veterinario = v.Nombre,
            Mascotas = (from c in _context.Citas 
                        join m in _context.Mascotas on c.IdMascotaFk equals m.Id
                        where c.IdVeterinarioFk == v.Id
                        select new
                        {
                            NombreMascota = m.Nombre,
                            FechaNacimiento = m.FechaNacimiento,
                        }).ToList()
        };
        
        if(!string.IsNullOrEmpty(search))
        {
            query = query.Where(p => p.Veterinario.ToLower().Contains(search));
        }

        query = query.OrderBy(p => p.Veterinario);
        var totalRegistros = await query.CountAsync();
        var registros = await query 
            .Skip((pageIndex - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

        return (totalRegistros, registros);
    }

    public virtual async Task<object> mascotasPertenecientesRaza()
    {
        var consulta =
        from r in _context.Razas
        select new
        {
            NombreRaza = r.Nombre,
            CantidadMascotas = _context.Mascotas.Distinct().Count(m => m.IdRazaFk == r.Id)
        };

        var MascotasPorRaza = await consulta.ToListAsync();
        return MascotasPorRaza;
    }
    public virtual async Task<(int totalRegistros,object registros)> mascotasPertenecientesRaza(int pageIndex, int pageSize, string search)
    {
        var query = 
                from r in _context.Razas
                select new
                {
                    NombreRaza = r.Nombre,
                    CantidadMascotas = _context.Mascotas.Distinct().Count(m => m.IdRazaFk == r.Id)
                };
        
        if(!string.IsNullOrEmpty(search))
        {
            query = query.Where(p => p.NombreRaza.ToLower().Contains(search));
        }

        query = query.OrderBy(p => p.NombreRaza);
        var totalRegistros = await query.CountAsync();
        var registros = await query 
            .Skip((pageIndex - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

        return (totalRegistros, registros);
    }
} 