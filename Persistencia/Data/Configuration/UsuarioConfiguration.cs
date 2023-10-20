using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration;
public class UserConfiguration : IEntityTypeConfiguration<Usuario>{
    public void Configure(EntityTypeBuilder<Usuario> builder)
    {
        {
            builder.ToTable("usuario");

            builder.Property(u => u.Id)
            .IsRequired();

            builder.Property(u => u.Nombre)
            .HasColumnName("nombre")
            .HasMaxLength(150)
            .IsRequired();

            builder.Property(u => u.Email)
           .HasColumnName("email")
           .IsRequired();

            builder.Property(u => u.Password)
           .HasMaxLength(250)
           .IsRequired();

            builder
           .HasMany(u => u.Rols)
           .WithMany(u => u.Usuarios)
           .UsingEntity<RolUsuario>(

               j => j
               .HasOne(pt => pt.Rol)
               .WithMany(t => t.RolUsuarios)
               .HasForeignKey(ut => ut.IdRolFk),


               j => j
               .HasOne(et => et.Usuario)
               .WithMany(et => et.RolUsuarios)
               .HasForeignKey(el => el.IdUsuarioFk),

               j =>
               {
                   j.ToTable("userRol");
                   j.HasKey(t => new { t.IdUsuarioFk, t.IdRolFk });

               });

            builder.HasMany(p => p.RefreshTokens)
            .WithOne(p => p.Usuario)
            .HasForeignKey(p => p.IdUsuarioFk);

            
        }

    }
}
