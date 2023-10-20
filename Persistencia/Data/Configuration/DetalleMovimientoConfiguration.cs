using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration;
    public class DetalleMovimientoConfiguration : IEntityTypeConfiguration<DetalleMovimiento>{
                public void Configure(EntityTypeBuilder<DetalleMovimiento> builder)
                {
                    builder.ToTable("detalleMovimiento");
        
                    builder.HasKey(d => d.Id);
    
                    builder.Property(d => d.Cantidad)
                    .HasColumnName("cantidad")
                    .HasColumnType("int")
                    .IsRequired();

                    builder.Property(p => p.Precio)
                    .HasColumnName("precio")
                    .HasColumnType("double")
                    .IsRequired();

                    builder.HasOne(m => m.Medicamento)
                    .WithMany(m => m.DetalleMovimientos)
                    .HasForeignKey(m => m.IdMedicamentoFk);

                    builder.HasOne(m => m.MovimientoMedicamento)
                    .WithMany(m => m.DetalleMovimientos)
                    .HasForeignKey(m => m.IdMovimientoMedicamentoFk);
                }
}
