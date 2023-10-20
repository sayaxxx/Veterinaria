namespace Dominio.Entities;
public class MovimientoMedicamento: BaseEntity{
    public int Cantidad { get; set; }
    public DateOnly Fecha { get; set; }
    public int IdTipoMovimientoFk { get; set; }
    public TipoMovimiento TipoMovimiento { get; set; }
    
    public ICollection<DetalleMovimiento> DetalleMovimientos { get; set; }

}
