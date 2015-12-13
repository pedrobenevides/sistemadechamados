using System.Data.Entity.ModelConfiguration;
using SistemaDeChamados.Domain.Entities;

namespace SistemaDeChamados.Infra.Data.Configuration
{
    public class ChamadoConfiguration : EntityTypeConfiguration<Chamado>
    {
        public ChamadoConfiguration()
        {
            Property(c => c.DataDeCriacao).IsRequired();
            Property(c => c.Descricao).IsRequired().HasMaxLength(500);
            HasMany(c => c.Mensagens).WithRequired().WillCascadeOnDelete(true);
            HasMany(c => c.Arquivos).WithRequired().WillCascadeOnDelete(true);
            Property(c => c.DataDeReabertura).IsOptional();
            HasMany(c => c.Arquivos);
        }
    }
}
