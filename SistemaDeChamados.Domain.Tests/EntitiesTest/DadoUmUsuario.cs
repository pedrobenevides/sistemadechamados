using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using SistemaDeChamados.Domain.Entities;
using SistemaDeChamados.Domain.Interfaces.Services;

namespace SistemaDeChamados.Domain.Tests.EntitiesTest
{
    [TestClass]
    public class DadoUmUsuario
    {
        private Usuario usuario;
        private ICriptografadorDeSenha criptografadorDeSenha;

        [TestInitialize]
        public void Setup()
        {
            usuario = new Usuario("pedro@mail.com", "Pedro");
            criptografadorDeSenha = Substitute.For<ICriptografadorDeSenha>();
        }

        [TestMethod]
        public void PossoDefinirOPasswordDoUsuario()
        {
            const string senha = "123456";
            criptografadorDeSenha.CriptografarSenha(senha).Returns("qwe123456wedr5468r7t421fc36dsfgkjrstedgaedr3");
            usuario.DefinirPassword(senha, criptografadorDeSenha);

            Assert.AreNotSame(senha, usuario.Password);
        }

        [TestMethod]
        public void PossoReativarUmUsuario()
        {
            usuario.AtivarUsuario();
            Assert.AreEqual(true, usuario.EstaAtivo);
        }

        [TestMethod]
        public void PossoDesativarUmUsuario()
        {
            usuario.DesativarUsuario();
            Assert.AreEqual(false, usuario.EstaAtivo);
        }

        [TestMethod]
        public void PossoAssociarUmSetorAoUsuario()
        {
            usuario.AssociarAoSetor(1);
            Assert.AreEqual(1, usuario.SetorId);
        }
    }
}
