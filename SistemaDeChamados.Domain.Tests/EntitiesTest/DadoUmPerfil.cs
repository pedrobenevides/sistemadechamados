using System.Collections.Generic;
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
        public void AoAdicionarPermissaoSemFormatacaoCorretaLancaChamadoException()
        {
            perfil.AdicionarAcao("nomeDaAcao");
        }

        [TestMethod]
        public void PossoAdicionarPermissaoComFormatacaoCorreta()
        {
            perfil.AdicionarAcao("nomeDaAcao;");
            Assert.AreNotEqual(string.Empty, perfil.Acoes);
        }

        [TestMethod]
        public void AoSolicitarAcoesFormatadasDeveRetornarUmaListaVaziaSePerfilNaoPossuiAcao()
        {
            var acoesFormatadas = perfil.ObterAcoesFormatadas();
            Assert.AreEqual(0, acoesFormatadas.Count());
        }

        [TestMethod]
        public void AoSolicitarAcoesFormatadasDeveRetornarUmaListaComAsAcoesSePossuir()
        {
            perfil.AdicionarAcao("testeAcao;");
            var acoesFormatadas = perfil.ObterAcoesFormatadas();

            Assert.AreEqual(1, acoesFormatadas.Count());
        }
    }
}
