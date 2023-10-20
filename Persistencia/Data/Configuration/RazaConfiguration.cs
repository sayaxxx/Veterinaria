using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration;
public class RazaConfiguration : IEntityTypeConfiguration<Raza>{
            public void Configure(EntityTypeBuilder<Raza> builder)
            {
                builder.ToTable("raza");
    
                builder.HasKey(r => r.Id);

                builder.Property(r => r.Nombre)
                .HasColumnName("nombre")
                .HasColumnType("varchar")
                .HasMaxLength(150)
                .IsRequired();

                builder.HasOne(r => r.Especie)
                .WithMany(r => r.Razas)
                .HasForeignKey(r => r.IdEspecieFk);
            }
}
