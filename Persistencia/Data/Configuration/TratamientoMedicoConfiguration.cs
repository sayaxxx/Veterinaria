using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration;
public class TratamientoMedicoConfiguration : IEntityTypeConfiguration<TratamientoMedico>{
            public void Configure(EntityTypeBuilder<TratamientoMedico> builder)
            {
                builder.ToTable("tratamientoMedico");
    
                builder.HasKey(t => t.Id);

                builder.Property(t => t.Dosis)
                .HasColumnName("dosis")
                .HasColumnType("int")
                .IsRequired();

                builder.Property(t => t.FechaAdministracion)
                .HasColumnName("fechaAdministracion")
                .HasColumnType("datetime")
                .IsRequired();

                builder.Property(t => t.Observacion)
                .HasColumnName("observacion")
                .HasColumnType("varchar")
                .HasMaxLength(250)
                .IsRequired();
            }
}
