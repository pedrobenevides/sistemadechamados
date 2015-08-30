using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using SistemaDeChamados.Application.AppServices;
using SistemaDeChamados.Application.Interface;
using SistemaDeChamados.Application.Interface.Services;
using SistemaDeChamados.Domain.Interfaces.Services;

namespace SistemaDeChamados.Application.Tests
{
    [TestClass]
    public class DadoUmUsuarioAppService
    {
        private IUsuarioAppService usuarioAppService;
        private IUsuarioService usuarioService;
        private IPerfilService perfilService;
        private IServiceLocator serviceLocator;

        [TestInitialize]
        public void Inicio()
        {
            usuarioService = Substitute.For<IUsuarioService>();
            perfilService = Substitute.For<IPerfilService>();
            serviceLocator = Substitute.For<IServiceLocator>();
            usuarioAppService = new UsuarioAppService(usuarioService, perfilService, serviceLocator);
        }
        
        [TestMethod, Ignore]
        public void PossoAlterarStatusDoUsuario()
        {
            usuarioAppService.AlterarStatus(1);
            usuarioService.Received().AlterarStatus(1);
        }
    }
}
