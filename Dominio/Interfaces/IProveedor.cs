using Dominio.Entities;

namespace Dominio.Interfaces;
public interface IProveedor : IGenericRepo<Proveedor>{
    Task<object> medicamentoProveedoresEspe(); //4B
    Task<(int totalRegistros, object registros)> medicamentoProveedoresEspe(int pageIndex, int pageSize, string search);

}
