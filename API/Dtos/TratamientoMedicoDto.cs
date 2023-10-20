namespace API.Dtos;
public class TratamientoMedicoDto
{
    public int Id { get; set; }
    public int IdCitaFk { get; set; }
    public CitaDto Cita { get; set; }
    public int IdMedicamentoFk { get; set; }
    public MedicamentoDto Medicamento { get; set; }
    public int Dosis { get; set; }
    public DateTime FechaAdministracion { get; set; }
    public string Observacion { get; set; }
}
