using System.Collections.Generic;
using AutoMapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using SistemaDeChamados.Application.AppServices;
using SistemaDeChamados.Application.Interface;
using SistemaDeChamados.Application.Interface.Services;
using SistemaDeChamados.Application.ViewModels;
using SistemaDeChamados.Domain.Entities;
using SistemaDeChamados.Domain.Interfaces.Services;

namespace SistemaDeChamados.Application.Tests
{
    [TestClass]
    public class DadoUmChamadoAppService
    {
        private IChamadoAppService chamadoAppService;
        private IChamadoService chamadoService;
        private IServiceLocator serviceLocator;

        [TestInitialize]
        public void Cenario()
        {
            chamadoService = Substitute.For<IChamadoService>();
            serviceLocator = Substitute.For<IServiceLocator>();
            chamadoAppService = new ChamadoAppService(chamadoService, serviceLocator);

            Mapper.CreateMap<CriacaoChamadoVM, Chamado>();
            Mapper.CreateMap<Chamado, ChamadoIndexVM>();
            Mapper.CreateMap<Chamado, ChamadoVM>();
        }

        [TestMethod]
        public void AoCriarUmChamadoDeveSerChamadoOMetodoCreateNoServico()
        {
            var vm = new CriacaoChamadoVM
            {
                CategoriaId = 1,
                Descricao = "Teste",
                SetorId = 1,
                Titulo = "Testando 1,2,3",
                UsuarioId = 1
            };

            chamadoAppService.CreateAsync(vm);
            chamadoService.Received().Create(Arg.Any<Chamado>());
        }

        [TestMethod]
        public void AoObterOsChamadosDeveSerMapeadoParaChamadoIndexVM()
        {
            var chamadoIndexVms = chamadoAppService.Retrieve();
            Assert.AreEqual(typeof(List<ChamadoIndexVM>), chamadoIndexVms.GetType());
        }

        [TestMethod]
        public void AoObterOsChamadosDeveObterNoServico()
        {
            chamadoAppService.Retrieve();
            chamadoService.Received().Obter();
        }

        [TestMethod]
        public void AoExcluirChamadoDeveSerChamadoOMetodoDeleteDoServico()
        {
            chamadoAppService.Delete(1);
            chamadoService.Received().Delete(1);
        }

        [TestMethod]
        public void AoObterChamadoPorIdDeveObterNoServico()
        {
            chamadoAppService.GetById(1);
            chamadoService.Received().GetById(1);
        }


        [TestMethod]
        public void AoObterChamadoPorIdDeveSerMapeadoParaChamadoVM()
        {
            chamadoService.GetById(1).Returns(new Chamado("Teste", "Testando", 1, 1));
            var chamadoVM = chamadoAppService.GetById(1);
            Assert.AreEqual(typeof(ChamadoVM), chamadoVM.GetType());
        }
    }
}
