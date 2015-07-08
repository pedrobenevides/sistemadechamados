using System;
using System.Linq;
using SistemaDeChamados.Domain.Entities;
using SistemaDeChamados.Domain.Enums;

namespace SistemaDeChamados.Infra.Data.Migrations
{
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<Contexto.SistemaContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(Contexto.SistemaContext context)
        {
            context.Usuarios.Add(new Usuario
            {
                Email = "teste@mail.com",
                EstaAtivo = true,
                Nome = "Pedro Benevides",
                Password = "123456"
            });

            var usuario = context.Usuarios.FirstOrDefault();

            //context.Chamados.Add(new Chamado
            //{
            //    DataDeCriacao = DateTime.Now,
            //    StatusDoChamado = StatusDoChamado.Aberto,
            //    Titulo = "Sem Rede",
            //    Descricao = "blablabla",
            //    UsuarioCriadorId = 1, 
                
            //});

            context.SaveChanges();
        }
    }
}
