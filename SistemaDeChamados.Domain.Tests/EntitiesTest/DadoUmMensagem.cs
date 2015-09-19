using Microsoft.VisualStudio.TestTools.UnitTesting;
using SistemaDeChamados.Domain.Entities;

namespace SistemaDeChamados.Domain.Tests.EntitiesTest
{
    [TestClass]
    public class DadoUmMensagem
    {
        private Mensagem mensagem;

        [TestInitialize]
        public void Setup()
        {
            mensagem = new Mensagem("Qual o produto com erro ?", 1, 1);
        }

        [TestMethod]
        public void PossoConfirmarLeituraDaMensagemSeUsuarioLeitorForDiferenteDoCriadorDaMensagem()
        {
            mensagem.ConfirmarLeitura(2);
            Assert.AreEqual(true, mensagem.DataDaLeitura.HasValue);
        }

        [TestMethod]
        public void NaoPossoConfirmarLeituraDaMensagemSeUsuarioLeitorForIgualDoCriadorDaMensagem()
        {
            mensagem.ConfirmarLeitura(1);
            Assert.AreEqual(false, mensagem.DataDaLeitura.HasValue);
        }
    }
}
