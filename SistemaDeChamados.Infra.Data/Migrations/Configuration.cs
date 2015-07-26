using System.Data.Entity.Migrations;
using System.Data.Entity.Validation;
using System.Text;
using SistemaDeChamados.Domain.Entities;
using SistemaDeChamados.Domain.Services;
using SistemaDeChamados.Infra.Data.Contexto;

namespace SistemaDeChamados.Infra.Data.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<SistemaContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(SistemaContext context)
        {
            //var usuario = new Usuario("teste@mail.com", "Pedro Benevides");
            //usuario.DefinirPassword("123456", new CriptografadorDeSenhaMD5());
            //context.Usuarios.Add(usuario);
            //var usuario = context.Usuarios.FirstOrDefault();

            //context.Chamados.Add(new Chamado
            //{
            //    DataDeCriacao = DateTime.Now,
            //    StatusDoChamado = StatusDoChamado.Aberto,
            //    Titulo = "Sem Rede",
            //    Descricao = "blablabla",
            //    UsuarioCriadorId = 1, 
                
            //});

            try
            {
                context.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                var sb = new StringBuilder();

                foreach (var failure in ex.EntityValidationErrors)
                {
                    sb.AppendFormat("{0} failed validation\n", failure.Entry.Entity.GetType());
                    foreach (var error in failure.ValidationErrors)
                    {
                        sb.AppendFormat("- {0} : {1}", error.PropertyName, error.ErrorMessage);
                        sb.AppendLine();
                    }
                }

                throw new DbEntityValidationException("Entity Validation Failed - errors follow:\n" + sb.ToString(), ex); 
            }
        }
    }
}
