using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration;
public class MascotaConfiguration : IEntityTypeConfiguration<Mascota>{
            public void Configure(EntityTypeBuilder<Mascota> builder)
            {
                builder.ToTable("mascota");
    
                builder.HasKey(m => m.Id);

                builder.Property(m => m.Nombre)
                .HasColumnName("nombre")
                .HasColumnType("varchar")
                .HasMaxLength(150)
                .IsRequired();

                builder.Property(m => m.FechaNacimiento)
                .HasColumnName("fechaNacimiento")
                .HasColumnType("date")
                .IsRequired();
                
                builder.HasOne(p => p.Propietario)
                .WithMany(p => p.Mascotas)
                .HasForeignKey(p => p.IdPropietarioFk);

                builder.HasOne(r => r.Raza)
                .WithMany(r => r.Mascotas)
                .HasForeignKey(r => r.IdRazaFk);
            }
}
