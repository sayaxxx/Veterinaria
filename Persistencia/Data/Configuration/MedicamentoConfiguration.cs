using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration;
public class MedicamentoConfiguration : IEntityTypeConfiguration<Medicamento>{
            public void Configure(EntityTypeBuilder<Medicamento> builder)
            {
                builder.ToTable("medicamento");
    
                builder.HasKey(m => m.Id);

                builder.Property(m => m.Nombre)
                .HasColumnName("nombre")
                .HasColumnType("varchar")
                .HasMaxLength(50)
                .IsRequired();

                builder.Property(m => m.CantidadDisponible)
                .HasColumnName("cantidadDisponible")
                .HasColumnType("int")
                .IsRequired();

                builder.Property(m => m.Precio)
                .HasColumnName("precio")
                .HasColumnType("int")
                .IsRequired();

                builder.HasOne(m => m.Laboratorio)
                .WithMany(m => m.Medicamentos)
                .HasForeignKey(m => m.IdLaboratorioFk);
            }
}
