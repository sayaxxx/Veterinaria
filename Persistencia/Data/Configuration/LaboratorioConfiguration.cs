using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration;
public class LaboratorioConfiguration : IEntityTypeConfiguration<Laboratorio>{
            public void Configure(EntityTypeBuilder<Laboratorio> builder)
            {
                builder.ToTable("laboratorio");
    
                builder.HasKey(l => l.Id);

                builder.Property(l => l.Nombre)
                .HasColumnName("nombre")
                .HasColumnType("varchar")
                .HasMaxLength(150)
                .IsRequired();

                builder.Property(l => l.Direccion)
                .HasColumnName("direccion")
                .HasColumnType("varchar")
                .HasMaxLength(250)
                .IsRequired();

                builder.Property(l => l.Telefono)
                .HasColumnName("telefono")
                .HasColumnType("varchar")
                .HasMaxLength(15)
                .IsRequired();
            }
}

