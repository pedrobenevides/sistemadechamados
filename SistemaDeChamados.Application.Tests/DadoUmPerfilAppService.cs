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
    public class DadoUmPerfilAppService
    {
        private IPerfilAppService perfilAppService;
        private IPerfilService perfilService;
        private PerfilVM perfilVM;
        private IServiceLocator serviceLocator;

        [TestInitialize]
        public void Setup()
        {
            perfilService = Substitute.For<IPerfilService>();
            serviceLocator = Substitute.For<IServiceLocator>();
            perfilAppService = new PerfilAppService(perfilService, serviceLocator);
            perfilVM = new PerfilVM
            {
                Nome = "Novo Perfil"
            };

            Mapper.CreateMap<PerfilVM, Perfil>();
            Mapper.CreateMap<Perfil, PerfilVM>();
        }

        [TestMethod]
        public void NoCreateDeveSerMapearVMParaEntidadeEChamadoOCreateServico()
        {
            var perfil = Mapper.Map<Perfil>(perfilVM);
            perfilAppService.Create(perfilVM);
            perfilService.Received().Create(Arg.Is<Perfil>(p => p.Id == perfil.Id && p.Nome == perfil.Nome));
        }

        [TestMethod]
        public void AoEditarPerfilDeverSerMapeadoParaEntidadeEChamadoOUpdateDoServico()
        {
            perfilVM.Id = 1;
            perfilAppService.Editar(perfilVM);
            perfilService.Received().Update(Arg.Is<Perfil>(p => p.Id == perfilVM.Id && p.Nome == perfilVM.Nome));
        }
    }
}
