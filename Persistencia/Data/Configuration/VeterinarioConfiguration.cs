using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration;
    public class VeterinarioConfiguration : IEntityTypeConfiguration<Veterinario>{
                public void Configure(EntityTypeBuilder<Veterinario> builder)
                {
                    builder.ToTable("veterinarios");
        
                    builder.HasKey(v => v.Id);
    
                    builder.Property(v => v.Nombre)
                    .HasColumnName("nombre")
                    .HasMaxLength(150)
                    .IsRequired();

                    builder.Property(v => v.Email)
                    .HasColumnName("email")
                    .IsRequired();

                    builder.Property(v => v.Telefono)
                    .HasColumnName("telefono")
                    .IsRequired();

                    builder.Property(v => v.Especialidad)
                    .HasColumnName("especialidad")
                    .HasMaxLength(250)
                    .IsRequired();
                }
}
