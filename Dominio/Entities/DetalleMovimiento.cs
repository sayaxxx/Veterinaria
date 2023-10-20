namespace Dominio.Entities;
public class DetalleMovimiento : BaseEntity{
    public int IdMedicamentoFk { get; set; }
    public Medicamento Medicamento { get; set; }
    public int Cantidad { get; set; }
    public int IdMovimientoMedicamentoFk { get; set; }
    public MovimientoMedicamento MovimientoMedicamento { get; set; }
    public double Precio { get; set; }


}
