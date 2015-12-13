using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using SistemaDeChamados.Domain.Entities;
using SistemaDeChamados.Infra.Data.Configuration;

namespace SistemaDeChamados.Infra.Data.Contexto
{
    public class SistemaContext : DbContext
    {
        public SistemaContext()
            : base("ChamadosDb")
        { }

        public DbSet<Chamado> Chamados { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Setor> Setores { get; set; }
        public DbSet<Mensagem> Mensagens { get; set; }
        public DbSet<Perfil> Perfis { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Colaborador> Colaboradores { get; set; }
        public DbSet<Analista> Analistas { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Properties<string>().Configure(c => c.HasColumnType("VARCHAR"));

            modelBuilder.Configurations.Add(new ChamadoConfiguration());
            modelBuilder.Configurations.Add(new MensagemConfiguration());
            modelBuilder.Configurations.Add(new UsuarioConfiguration());
            modelBuilder.Configurations.Add(new PerfilConfiguration());
            modelBuilder.Configurations.Add(new ColaboradorConfiguration());
            modelBuilder.Configurations.Add(new AnalistaConfiguration());
            modelBuilder.Configurations.Add(new ArquivoConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
