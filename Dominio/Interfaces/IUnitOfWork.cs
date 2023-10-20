namespace Dominio.Interfaces;
public interface IUnitOfWork{
    ICita Citas { get; }
    IDetalleMovimiento DetalleMovimientos { get; }
    IEspecie Especies { get; }
    ILaboratorio Laboratorios { get; }
    IMascota Mascotas { get; }
    IMedicamento Medicamentos { get; }
    IMovimientoMedicamento MovimientoMedicamentos { get; }
    IPropietario Propietarios { get; }
    IProveedor Proveedores { get; }
    IRaza Razas { get; }
    IRol Roles { get; }
    ITipoMovimiento TipoMovimientos { get; }
    ITratamientoMedico TratamientoMedicos { get; }
    IUsuario Usuarios { get; }
    IVeterinario Veterinarios { get; }

    Task<int> SaveAsync();
}
