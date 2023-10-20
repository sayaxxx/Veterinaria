using Dominio.Entities;

namespace Dominio.Interfaces;
public interface IMascota : IGenericRepo<Mascota>{
    Task<object> mascotasFelinas(); // 3A
    Task<(int totalRegistros, object registros)> mascotasFelinas(int pageIndex, int pageSize, string search);
    Task<object> vacunacion2023(); // 6A
    Task<(int totalRegistros, object registros)> vacunacion2023(int pageIndex, int pageSize, string search);
    Task<object> mascotasPorEspecie(); //1B
    Task<(int totalRegistros, object registros)> mascotasPorEspecie(int pageIndex, int pageSize, string search);
    Task<object> mascotasAtendidasVeterinario(); //3B
    Task<(int totalRegistros, object registros)> mascotasAtendidasVeterinario(int pageIndex, int pageSize, string search);
    Task<object> cantidadMascotasRaza(); //6B
    Task<(int totalRegistros, object registros)> cantidadMascotasRaza(int pageIndex, int pageSize, string search);
}