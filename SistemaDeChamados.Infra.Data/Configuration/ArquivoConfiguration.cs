using System.Data.Entity.ModelConfiguration;
using SistemaDeChamados.Domain.Entities;

namespace SistemaDeChamados.Infra.Data.Configuration
{
    public class ArquivoConfiguration : EntityTypeConfiguration<Arquivo>
    {
        public ArquivoConfiguration()
        {
            Property(a => a.ChamadoId).IsRequired();
            Ignore(a => a.Stream);
        }
    }
}
