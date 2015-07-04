using System.Data.Entity.ModelConfiguration;
using SistemaDeChamados.Domain.Entities;

namespace SistemaDeChamados.Infra.Data.Configuration
{
    public class UsuarioConfiguration :EntityTypeConfiguration<Usuario>
    {
        public UsuarioConfiguration()
        {
            Property(u => u.Nome).HasMaxLength(100).IsRequired();
            Property(u => u.Password).HasMaxLength(100).IsRequired();
        }
    }
}