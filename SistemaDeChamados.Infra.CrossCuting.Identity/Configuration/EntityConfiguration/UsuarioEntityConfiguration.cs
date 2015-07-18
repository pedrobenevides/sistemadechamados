using System.Data.Entity.ModelConfiguration;
using SistemaDeChamados.Infra.CrossCuting.Identity.Entities;

namespace SistemaDeChamados.Infra.CrossCuting.Identity.Configuration.EntityConfiguration
{
    public class UsuarioEntityConfiguration : EntityTypeConfiguration<UsuarioIdentity>
    {
        public UsuarioEntityConfiguration()
        {
            Property(u => u.UsuarioId).IsRequired();            
        }
    }
}
