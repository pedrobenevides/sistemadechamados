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
    public class DadoUmSetorAppService
    {
        private ISetorAppService setorAppService;
        private ISetorService setorService;
        private IServiceLocator serviceLocator;

        [TestInitialize]
        public void Setup()
        {
            setorService = Substitute.For<ISetorService>();
            serviceLocator = Substitute.For<IServiceLocator>();
            setorAppService = new SetorAppService(setorService, serviceLocator);
            Mapper.CreateMap<Setor, SetorVM>();
            Mapper.CreateMap<SetorVM, Setor>();
        }

        [TestMethod]
        public void AoObterSetorPorUsuarioIdORetornoDeveSerSetorVM()
        {
            setorService.ObterPorUsuarioId(1).Returns(new Setor("Teste"));
            var result = setorAppService.ObterPorUsuarioId(1);

            Assert.AreEqual(typeof(SetorVM), result.GetType());
        }
    }
}
