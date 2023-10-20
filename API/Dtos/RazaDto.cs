namespace API.Dtos;
public class RazaDto
{
    public int Id { get; set; }
    public int IdEspecieFk { get; set; }
    public EspecieDto Especie { get; set; }
    public string Nombre { get; set; }
    public virtual MascotaDto Mascota { get; set; }
}
