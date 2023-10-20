using Dominio.Entities;

namespace Dominio.Interfaces;
public interface IMedicamento : IGenericRepo<Medicamento>{
    Task<object> medicamentosMayor50000(); //5A
    Task<(int totalRegistros, object registros)> medicamentosMayor50000(int pageIndex, int pageSize, string search);

}
