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
            HasRequired(c => c.UsuarioCriador);
            HasMany(c => c.Mensagens);
        }
    }
}
