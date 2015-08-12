using System.Data.Entity.Migrations;
using System.Data.Entity.Validation;
using System.Text;
using SistemaDeChamados.Domain.Entities;
using SistemaDeChamados.Domain.Enums;
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
            var setorFinanceiro = new Setor("Financeiro");
            var setorComercial = new Setor("Comercial");
            var setorTI = new Setor("TI");

            context.Setores.Add(setorFinanceiro);
            context.Setores.Add(setorComercial);
            context.Setores.Add(setorTI);

            var perfilAdmin = new Perfil("Administrador");
            perfilAdmin.AdicionarAcesso("*;");
            
            context.Perfis.Add(perfilAdmin);

            context.SaveChanges();

            var categoria = new Categoria("Instalação de Software", setorTI.Id);
            var categoria2 = new Categoria("Cotação de Mercadoria", setorComercial.Id);

            context.Categorias.Add(categoria);
            context.Categorias.Add(categoria2);

            var usuario = new Usuario("teste@mail.com", "Pedro Benevides", TipoUsuario.Comum);
            usuario.DefinirPassword("123456", new CriptografadorDeSenhaMD5());
            usuario.AssociarAoSetor(setorTI.Id);
            usuario.AssociarPerfil(perfilAdmin.Id);
            
            var usuario2 = new Usuario("josilva@mail.com", "Joao Silva", TipoUsuario.Comum);
            usuario2.DefinirPassword("123456", new CriptografadorDeSenhaMD5());
            usuario2.AssociarAoSetor(setorFinanceiro.Id);
            
            var usuario3 = new Usuario("chicomatos@mail.com", "Francisco Matos", TipoUsuario.Analista);
            usuario3.DefinirPassword("123456", new CriptografadorDeSenhaMD5());
            usuario3.AssociarAoSetor(setorFinanceiro.Id);
            
            context.Usuarios.Add(usuario);
            context.Usuarios.Add(usuario2);
            context.Usuarios.Add(usuario3);

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
