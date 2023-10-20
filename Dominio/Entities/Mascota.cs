namespace Dominio.Entities;
public class Mascota : BaseEntity{
    public int IdPropietarioFk { get; set; }
    public Propietario Propietario { get; set; }
    public int IdRazaFk { get; set; }
    public Raza Raza { get; set; }
    public string Nombre { get; set; }
    public DateOnly FechaNacimiento { get; set; }

    public ICollection<Cita> Citas { get; set; }
}
