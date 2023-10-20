using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration;
public class PropietarioConfiguration : IEntityTypeConfiguration<Propietario>{
            public void Configure(EntityTypeBuilder<Propietario> builder)
            {
                builder.ToTable("propietario");
    
                builder.HasKey(p => p.Id);

                builder.Property(p => p.Nombre)
                .HasMaxLength(150)
                .IsRequired();

                builder.Property(p => p.Email)
                .HasMaxLength(150)
                .IsRequired();

                builder.Property(p => p.Telefono)
                .IsRequired();
            }
}
