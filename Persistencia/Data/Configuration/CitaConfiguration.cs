using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration;
public class CitaConfiguration : IEntityTypeConfiguration<Cita>{
            public void Configure(EntityTypeBuilder<Cita> builder)
            {
                builder.ToTable("cita");
    
                builder.HasKey(c => c.Id);

                builder.Property(c => c.Fecha)
                .HasColumnName("fecha")
                .HasColumnType("Date")
                .IsRequired();

                 builder.Property(c => c.Hora)
                .HasColumnName("hora")
                .HasColumnType("Datetime")
                .IsRequired();

                builder.Property(c => c.Motivo)
                .HasColumnName("motivo")
                .HasColumnType("varchar")
                .HasMaxLength(500)
                .IsRequired();

                builder.HasOne(v => v.Veterinario)
                .WithMany(v => v.Citas)
                .HasForeignKey(v => v.IdVeterinarioFk);

                builder.HasOne(m => m.Mascota)
                .WithMany(m => m.Citas)
                .HasForeignKey(m => m.IdMascotaFk);
            }
}

