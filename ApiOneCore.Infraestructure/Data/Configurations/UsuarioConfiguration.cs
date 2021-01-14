using ApOneCore.Core.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApiOneCore.Infraestructure.Data.Configurations
{
    public class UsuarioConfiguration : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("USUARIO");

            builder.Property(e => e.Id).HasDefaultValueSql("(newid())");

            builder.Property(e => e.Correo)
                .IsRequired()
                .IsUnicode(false);

            builder.Property(e => e.Estatus).HasDefaultValueSql("((1))");

            builder.Property(e => e.FechaCreacion)
                .HasColumnType("date")
                .HasDefaultValueSql("(getdate())");

            builder.Property(e => e.NombreUsuario)
                .IsRequired()
                .IsUnicode(false);

            builder.Property(e => e.Password)
                .IsRequired()
                .IsUnicode(false);

            builder.Property(e => e.Sexo)
                .IsRequired()
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
        }
    }
}
