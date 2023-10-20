using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration;
public class TipoMovimientoConfiguration : IEntityTypeConfiguration<TipoMovimiento>{
            public void Configure(EntityTypeBuilder<TipoMovimiento> builder)
            {
                builder.ToTable("tipoMovimiento");
    
                builder.HasKey(t => t.Id);

                builder.Property(t => t.Descripcion)
                .HasColumnName("descripcion")
                .HasColumnType("varchar")
                .HasMaxLength(250)
                .IsRequired();
            }
}
