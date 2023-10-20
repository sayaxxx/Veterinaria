using Dominio.Entities;

namespace Dominio.Interfaces;
public interface IPropietario : IGenericRepo<Propietario>{
    Task<object> propietariosMascotas(); //4A
    Task<(int totalRegistros, object registros)> propietariosMascotas(int pageIndex, int pageSize, string search);
    Task<object> goldenRetriver(); //5B
    Task<(int totalRegistros, object registros)> goldenRetriver(int pageIndex, int pageSize, string search);

}
