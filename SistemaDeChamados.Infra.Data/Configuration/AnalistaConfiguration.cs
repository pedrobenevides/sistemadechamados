using System.Data.Entity.ModelConfiguration;
using SistemaDeChamados.Domain.Entities;

namespace SistemaDeChamados.Infra.Data.Configuration
{
    public class AnalistaConfiguration : EntityTypeConfiguration<Analista>
    {
        public AnalistaConfiguration()
        {
            HasMany(c => c.Categorias).WithOptional().WillCascadeOnDelete(false);
            Map(c => c.Requires("TipoUsuario").HasValue(1).HasColumnType("int"));
        }
    }
}
