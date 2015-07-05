using System.Data.Entity.ModelConfiguration;
using SistemaDeChamados.Domain.Entities;

namespace SistemaDeChamados.Infra.Data.Configuration
{
    public class MensagemConfiguration : EntityTypeConfiguration<Mensagem>
    {
        public MensagemConfiguration()
        {
            HasRequired(m => m.Chamado);
            Property(m => m.Texto).IsRequired().HasMaxLength(1000);
            Property(m => m.DataDeCriacao).IsRequired();
        }
    }
}
