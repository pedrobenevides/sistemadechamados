using System.Data.Entity.ModelConfiguration;
using SistemaDeChamados.Domain.Entities;

namespace SistemaDeChamados.Infra.Data.Configuration
{
    public class ColaboradorConfiguration : EntityTypeConfiguration<Colaborador>
    {
        public ColaboradorConfiguration()
        {
            Property(c => c.SetorId).IsRequired();
            Property(c => c.PerfilId).IsOptional();
            Map(c => c.Requires("TipoUsuario").HasValue(0).HasColumnType("int"));

        }
    }
}
