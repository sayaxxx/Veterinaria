using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration;
public class EspecieConfiguration : IEntityTypeConfiguration<Especie>{
            public void Configure(EntityTypeBuilder<Especie> builder)
            {
                builder.ToTable("especie");
    
                builder.HasKey(e => e.Id);

                builder.Property(e => e.Nombre)
                .HasColumnName("nombre")
                .HasColumnType("varchar")
                .HasMaxLength(150)
                .IsRequired();
            }
}
