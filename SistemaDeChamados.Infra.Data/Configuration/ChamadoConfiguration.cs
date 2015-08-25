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
            Property(c => c.UsuarioCriadorId);

            //HasRequired(c => c.UsuarioCriador).WithOptional().WillCascadeOnDelete(false);
            HasMany(c => c.Mensagens);
            Property(c => c.DataDeReabertura).IsOptional();
        }
    }
}
