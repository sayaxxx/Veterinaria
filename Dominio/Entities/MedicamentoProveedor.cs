namespace Dominio.Entities;
public class MedicamentoProveedor{
    public int IdMedicamentoFk { get; set; }
    public Medicamento Medicamento{ get; set; }
    public int IdProveedorFk { get; set; }
    public Proveedor Proveedor { get; set; }
}
