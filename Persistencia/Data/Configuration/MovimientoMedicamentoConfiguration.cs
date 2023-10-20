using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration;
    public class MovimientoMedicamentoConfiguration : IEntityTypeConfiguration<MovimientoMedicamento>{
                public void Configure(EntityTypeBuilder<MovimientoMedicamento> builder)
                {
                    builder.ToTable("movimientoMedicamento");
        
                    builder.HasKey(m => m.Id);
    
                    builder.Property(m => m.Cantidad)
                    .HasColumnName("cantidad")
                    .HasColumnType("int")
                    .IsRequired();

                    builder.Property(m => m.Fecha)
                    .HasColumnName("fecha")
                    .HasColumnType("date")
                    .IsRequired();

                    builder.HasOne(m => m.TipoMovimiento)
                    .WithMany(m => m.MovimientoMedicamentos)
                    .HasForeignKey(m => m.IdTipoMovimientoFk); 
                }
}
    