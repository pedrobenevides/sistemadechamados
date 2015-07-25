using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using SistemaDeChamados.Application.AppServices;
using SistemaDeChamados.Application.Interface;
using SistemaDeChamados.Domain.Interfaces.Services;

namespace SistemaDeChamados.Application.Tests
{
    [TestClass]
    public class DadoUmUsuarioAppService
    {
        private IUsuarioAppService usuarioAppService;
        private IUsuarioService usuarioService;

        [TestInitialize]
        public void Inicio()
        {
            usuarioService = Substitute.For<IUsuarioService>();
            usuarioAppService = new UsuarioAppService(usuarioService);
        }

        
        [TestMethod]
        public void PossoAlterarStatusDoUsuario()
        {
            
            usuarioAppService.AlterarStatus(1);
            usuarioService.Received().AlterarStatus(1);
        }
    }
}
