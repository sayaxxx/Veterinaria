using Dominio.Entities;

namespace Dominio.Interfaces;
public interface ILaboratorio : IGenericRepo<Laboratorio>{
    Task<object> listarMedicamentosGenfar(); //2A
    Task<(int totalRegistros, object registros)> listarMedicamentosGenfar(int pageIndex, int pageSize, string search); //2A
}
