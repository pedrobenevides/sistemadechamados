﻿using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using SistemaDeChamados.Domain.Interfaces.Repositories;
using SistemaDeChamados.Domain.Interfaces.Services;
using SistemaDeChamados.Domain.Services;
using SistemaDeChamados.Domain.VO;

namespace SistemaDeChamados.Domain.Tests.ServicesTest
{
    [TestClass]
    public class DadoUmPerfilService
    {
        private IPerfilService perfilService;
        private IPerfilRepository perfilRepository;

        [TestInitialize]
        public void Setup()
        {
            perfilRepository = Substitute.For<IPerfilRepository>();
            perfilService = new PerfilService(perfilRepository);
        }

        [TestMethod]
        public void AoObterTodosAcessosDePerfilRetornaUmaListaDeAcessoVO()
        {
            var todosAcessosDePerfil = perfilService.TodosAcessosDePerfil();
            Assert.AreEqual(typeof(List<AcessoVO>), todosAcessosDePerfil.GetType());
        }
    }
}
