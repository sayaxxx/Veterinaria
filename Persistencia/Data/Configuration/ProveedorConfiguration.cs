using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration;
public class ProveedorConfiguration : IEntityTypeConfiguration<Proveedor>{
            public void Configure(EntityTypeBuilder<Proveedor> builder)
            {
                builder.ToTable("proveedor");
    
                builder.HasKey(p => p.Id);

                builder.Property(p => p.Nombre)
                .HasColumnName("nombre")
                .HasColumnType("varchar")
                .HasMaxLength(150)
                .IsRequired();

                builder
                .HasMany(p => p.Medicamentos)
                .WithMany(p => p.Proveedores)
                .UsingEntity<MedicamentoProveedor>(
                  j => j
                    .HasOne(pt => pt.Medicamento)
                    .WithMany(t => t.MedicamentoProveedores)
                    .HasForeignKey(pt => pt.IdMedicamentoFk),
                  j => j
                    .HasOne(pt => pt.Proveedor)
                    .WithMany(t => t.MedicamentoProveedores)
                    .HasForeignKey(pt => pt.IdProveedorFk),
                  j => 
                    {
                      j.HasKey(t => new {t.IdProveedorFk, t.IdMedicamentoFk});
                    });
            }
}