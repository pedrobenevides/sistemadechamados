using System.Collections.Generic;
using System.Threading.Tasks;
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
    public class DadoUmColaboradorAppService
    {
        private IColaboradorAppService colaboradorAppService;
        private IServiceLocator serviceLocator;
        private IColaboradorService colaboradorService;
        private IUsuarioService usuarioService;
        private IPerfilService perfilService;

        [TestInitialize]
        public void Cenario()
        {
            colaboradorService = Substitute.For<IColaboradorService>();
            usuarioService = Substitute.For<IUsuarioService>();
            perfilService = Substitute.For<IPerfilService>();
            serviceLocator = Substitute.For<IServiceLocator>();

            colaboradorAppService = new ColaboradorAppService(colaboradorService, usuarioService, perfilService, serviceLocator);
            Mapper.CreateMap<ColaboradorVM, Colaborador>();
        }

        [TestMethod]
        public void AoObterColaboradoresChamaOMetodoObterNoServico()
        {
            colaboradorAppService.Obter();
            colaboradorService.Received().Obter();
        }

        [TestMethod]
        public void AoObterColaboradoresRetornaUmaListaDeColaboradorVM()
        {
            var colaboradores = colaboradorAppService.Obter();
            Assert.AreEqual(typeof(List<ColaboradorVM>), colaboradores.GetType());
        }

        [TestMethod]
        public void AoObterColaboradoresAsynChamaOMetodoObterAsyncNoServico()
        {
            colaboradorAppService.ObterAsync();
            colaboradorService.Received().ObterAsync();
        }

        [TestMethod]
        public async Task AoObterAsyncColaboradoresRetornaUmaListaDeColaboradorVM()
        {
            var colaboradores = await colaboradorAppService.ObterAsync();
            Assert.AreEqual(typeof(List<ColaboradorVM>), colaboradores.GetType());
        }


        [TestMethod]
        public void AoCriarColaboradorDeveChamarOMetodoCreateNoServico()
        {
            var vm = new ColaboradorVM
            {
                Nome = "Pedro",
                Email = "teste@mail.com",
                Password = "123456",
                ConfirmacaoPassword = "123456",
                SetorId = 1,
                PerfilId = 1
            };

            colaboradorAppService.Create(vm);
            colaboradorService.Received().Create(Arg.Any<Usuario>());
        }

    }
}
