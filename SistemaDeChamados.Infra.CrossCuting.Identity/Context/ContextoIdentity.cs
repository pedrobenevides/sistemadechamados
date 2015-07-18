using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using SistemaDeChamados.Infra.CrossCuting.Identity.Configuration.EntityConfiguration;
using SistemaDeChamados.Infra.CrossCuting.Identity.Entities;

namespace SistemaDeChamados.Infra.CrossCuting.Identity.Context
{
    public class ContextoIdentity : IdentityDbContext<UsuarioIdentity>
    {
        public ContextoIdentity()
            : base("ChamadosDb", throwIfV1Schema: false)
        { }

        public static ContextoIdentity Create()
        {
            return new ContextoIdentity();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new UsuarioEntityConfiguration());
            modelBuilder.Properties<string>().Configure(c => c.HasColumnType("VARCHAR"));
            base.OnModelCreating(modelBuilder);
        }
    }
}
