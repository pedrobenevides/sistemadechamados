using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SistemaDeChamados.Domain.Entities;
using SistemaDeChamados.Domain.Exceptions;

namespace SistemaDeChamados.Domain.Tests.EntitiesTest
{
    [TestClass]
    public class DadoUmPerfil
    {
        private Perfil perfil;

        [TestInitialize]
        public void Setup()
        {
            perfil = new Perfil("Teste Perfil");
        }

        [TestMethod, ExpectedException(typeof(ChamadosException))]
        public void AoAdicionarAcessoSemFormatacaoCorretaLancaChamadoException()
        {
            perfil.AdicionarAcesso("nomeDaAcao");
        }

        [TestMethod]
        public void PossoAdicionarAcessoComFormatacaoCorreta()
        {
            perfil.AdicionarAcesso("nomeDaAcao;");
            Assert.AreNotEqual(string.Empty, perfil.Acessos);
        }

        [TestMethod]
        public void AoSolicitarAcessosFormatadasDeveRetornarUmaListaVaziaSePerfilNaoPossuiAcesso()
        {
            var acoesFormatadas = perfil.ObterAcessosFormatados();
            Assert.AreEqual(0, acoesFormatadas.Count());
        }

        [TestMethod]
        public void AoSolicitarAcessosFormatadasDeveRetornarUmaListaComAsAcoesSePossuir()
        {
            perfil.AdicionarAcesso("testeAcao;");
            var acoesFormatadas = perfil.ObterAcessosFormatados();

            Assert.AreEqual(1, acoesFormatadas.Count());
        }
    }
}
