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
            
            context.SaveChanges();

            var colaborador1 = new Colaborador("teste@mail.com", "Pedro Benevides", setorTI.Id);
            colaborador1.DefinirPassword("123456", new CriptografadorDeSenhaMD5());
            colaborador1.AssociarAoSetor(setorTI.Id);
            colaborador1.AssociarPerfil(perfilAdmin.Id);

            var analista = new Analista("josilva@mail.com", "Joao Silva");
            analista.DefinirPassword("123456", new CriptografadorDeSenhaMD5());
            analista.AssociarCategoria(categoria);

            var colaborador2 = new Colaborador("chicomatos@mail.com", "Francisco Matos", setorComercial.Id);
            colaborador2.DefinirPassword("123456", new CriptografadorDeSenhaMD5());
            colaborador2.AssociarAoSetor(setorFinanceiro.Id);

            context.Usuarios.Add(colaborador1);
            context.Usuarios.Add(colaborador2);
            context.Usuarios.Add(analista);

            CreateHundredOfUsers(context, setorComercial.Id);

            context.SaveChanges();

            var chamado1 = new Chamado("Chamado Inicial", "Esse é um chamado de teste", colaborador1.Id, categoria.Id);
            context.Chamados.Add(chamado1);

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

        private static void CreateHundredOfUsers(SistemaContext context, long setorId)
        {
            for (var i = 0; i < 200; i++)
            {
                var colaborador2 = new Colaborador(string.Format("chicomatos{0}@mail.com", i), string.Format("Francisco Matos {0}", i), setorId);
                colaborador2.DefinirPassword("123456", new CriptografadorDeSenhaMD5());

                context.Usuarios.Add(colaborador2);
            }
        }
    }
}
