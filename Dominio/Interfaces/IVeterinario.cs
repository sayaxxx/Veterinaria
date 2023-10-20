using Dominio.Entities;

namespace Dominio.Interfaces;
public interface IVeterinario : IGenericRepo<Veterinario>{
    Task<object> veterinarioCirujano(); //1A
    Task<(int totalRegistros, object registros)> veterinarioCirujano(int pageIndex, int pageSize, string search);

}
