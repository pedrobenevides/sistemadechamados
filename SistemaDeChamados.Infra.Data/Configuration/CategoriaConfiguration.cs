using System.Data.Entity.ModelConfiguration;
using SistemaDeChamados.Domain.Entities;

namespace SistemaDeChamados.Infra.Data.Configuration
{
    public class CategoriaConfiguration : EntityTypeConfiguration<Categoria>
    {
        public CategoriaConfiguration()
        {
            Property(c => c.AnalistaId).IsOptional();
            Property(c => c.SetorId).IsRequired();
            Property(c => c.Nome).IsRequired();
        }
    }
}
