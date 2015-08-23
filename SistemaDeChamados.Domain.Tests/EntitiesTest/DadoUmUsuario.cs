using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using SistemaDeChamados.Domain.Entities;
using SistemaDeChamados.Domain.Enums;
using SistemaDeChamados.Domain.Interfaces.Services;

namespace SistemaDeChamados.Domain.Tests.EntitiesTest
{
    [TestClass]
    public class DadoUmUsuario
    {
        private Usuario usuario;
        private ICriptografadorDeSenha criptografadorDeSenha;

        [TestInitialize]
        public void Cenario()
        {
            //usuario = new Usuario("pedro@mail.com", "Pedro", TipoUsuario.Comum);
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

        //[TestMethod]
        //public void PossoAssociarUmSetorAoUsuario()
        //{
        //    usuario.AssociarAoSetor(1);
        //    Assert.AreEqual(1, usuario.SetorId);
        //}

        //[TestMethod]
        //public void PossoAssociarUmPerfil()
        //{
        //    usuario.AssociarPerfil(1);
        //    Assert.AreEqual(1, usuario.PerfilId);
        //}

        //[TestMethod]
        //public void PossoInformarUmTipoComum()
        //{
        //    usuario.InformarTipo(TipoUsuario.Comum);
        //    Assert.AreEqual(TipoUsuario.Comum, usuario.Tipo);
        //}

        //[TestMethod]
        //public void PossoInformarUmTipoAnalista()
        //{
        //    usuario.InformarTipo(TipoUsuario.Analista);
        //    Assert.AreEqual(TipoUsuario.Analista, usuario.Tipo);
        //}
    }
}
