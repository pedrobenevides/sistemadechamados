﻿using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using SistemaDeChamados.Domain.Entities;
using SistemaDeChamados.Infra.Data.Configuration;

namespace SistemaDeChamados.Infra.Data
{
    public class SistemaContext : DbContext
    {
        public SistemaContext()
            :base("conn")
        { }

        public DbSet<Chamado> Chamados { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Mensagem> Mensagens { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Properties<string>().Configure(c => c.HasColumnType("VARCHAR"));
            modelBuilder.Configurations.Add(new ChamadoConfiguration());
            modelBuilder.Configurations.Add(new MensagemConfiguration());
            modelBuilder.Configurations.Add(new UsuarioConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
