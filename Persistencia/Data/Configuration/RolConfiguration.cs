using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration;
public class RolConfiguration: IEntityTypeConfiguration<Rol>
{
    public void Configure(EntityTypeBuilder<Rol> builder)
    {

        builder.ToTable("rol");
        builder.HasKey(r => r.Id);
        
        builder.Property(r => r.Id)
        .IsRequired();
        
        builder.Property(r => r.Nombre)
        .HasColumnName("rolName")
        .HasColumnType("varchar")
        .HasMaxLength(250)
        .IsRequired();

    }
}

