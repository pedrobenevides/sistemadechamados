using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using NSubstitute.ReturnsExtensions;
using SistemaDeChamados.Domain.Entities;
using SistemaDeChamados.Domain.Exceptions;
using SistemaDeChamados.Domain.Interfaces.Repositories;
using SistemaDeChamados.Domain.Interfaces.Services;
using SistemaDeChamados.Domain.Services;

namespace SistemaDeChamados.Domain.Tests
{
    [TestClass]
    public class DadoUmUsuarioService
    {
        private IUsuarioService usuarioService;
        private IUsuarioRepository usuarioRepository;
        private ICriptografadorDeSenha criptografadorDeSenha;

        [TestInitialize]
        public void Setup()
        {
            usuarioRepository = Substitute.For<IUsuarioRepository>();
            criptografadorDeSenha = Substitute.For<ICriptografadorDeSenha>();
            usuarioService = new UsuarioService(usuarioRepository, criptografadorDeSenha);
        }

        [TestMethod, ExpectedException(typeof(ServiceException))]
        public void ThrowExceptionSeOLoginInformadoNaoPertencerANenhumUsuario()
        {
            const string email = "teste@mail.com";
            usuarioRepository.ObterPorEmail(email).ReturnsNull();
            usuarioService.ValidaSenhaInformada(email, "123456");
        }

        [TestMethod, ExpectedException(typeof(ServiceException))]
        public void ThrowExceptionSeASenhaInformadaNaoForAMesmaQueOUsuarioPossuiNoBanco()
        {
            const string email = "teste@mail.com";
            usuarioRepository.ObterPorEmail(email).Returns(new Usuario(email, "Pedro"));
            usuarioService.ValidaSenhaInformada(email, "123456");
        }
    }
}
