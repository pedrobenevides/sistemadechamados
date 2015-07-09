using Microsoft.VisualStudio.TestTools.UnitTesting;
using SistemaDeChamados.Domain.Exceptions;
using SistemaDeChamados.Domain.Interfaces.Services;
using SistemaDeChamados.Domain.Services;

namespace SistemaDeChamados.Domain.Tests
{
    [TestClass]
    public class DadoUmCriptografadorDeSenha
    {
        private ICriptografadorDeSenha criptografadorDeSenha;

        [TestInitialize]
        public void Setup()
        {
            criptografadorDeSenha = new CriptografadorDeSenhaMD5();
        }

        [TestMethod]
        public void DeveCriptografarString()
        {
            const string senhaPlana = "123456";
            var senhaCriptografada = criptografadorDeSenha.CriptografarSenha(senhaPlana);
            Assert.AreEqual(32, senhaCriptografada.Length);
        }

        [TestMethod, ExpectedException(typeof(CriptografadorException))]
        public void SeASenhaForVaziaOuNulaDeveSerLancadoException()
        {
            criptografadorDeSenha.CriptografarSenha(null);
        }
    }
}
