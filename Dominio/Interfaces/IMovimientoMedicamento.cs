using Dominio.Entities;

namespace Dominio.Interfaces;
public interface IMovimientoMedicamento : IGenericRepo<MovimientoMedicamento>{
    Task<object> movimientosMedicamentoValor(); //2B
    Task<(int totalRegistros, object registros)> movimientosMedicamentoValor(int pageIndex, int pageSize, string search);

}
