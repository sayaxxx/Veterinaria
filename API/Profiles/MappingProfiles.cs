using API.Dtos;
using AutoMapper;
using Dominio.Entities;

namespace API.Profiles;
public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        
        CreateMap<Cita,CitaDto>().ReverseMap();
        CreateMap<DetalleMovimiento,DetalleMovimientoDto>().ReverseMap();
        CreateMap<Especie,EspecieDto>().ReverseMap();
        CreateMap<Laboratorio,LaboratorioDto>().ReverseMap();
        CreateMap<Mascota,MascotaDto>().ReverseMap();
        CreateMap<Medicamento,MedicamentoDto>().ReverseMap();
        CreateMap<MovimientoMedicamento,MovimientoMedicamentoDto>().ReverseMap();
        CreateMap<Propietario,PropietarioDto>().ReverseMap();
        CreateMap<Proveedor,ProveedorDto>().ReverseMap();
        CreateMap<Raza,RazaDto>().ReverseMap();
        CreateMap<Rol,RolDto>().ReverseMap();
        CreateMap<TipoMovimiento,TipoMovimientoDto>().ReverseMap();
        CreateMap<TratamientoMedico,TratamientoMedicoDto>().ReverseMap();
        CreateMap<Usuario,UsuarioDto>().ReverseMap();
        CreateMap<Veterinario,VeterinarioDto>().ReverseMap();
        

    }
}
