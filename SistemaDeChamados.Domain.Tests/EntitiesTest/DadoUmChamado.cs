using Microsoft.VisualStudio.TestTools.UnitTesting;
using SistemaDeChamados.Domain.Entities;
using SistemaDeChamados.Domain.Enums;
using SistemaDeChamados.Domain.Exceptions;
using SistemaDeChamados.Domain.Interfaces;

namespace SistemaDeChamados.Domain.Tests.EntitiesTest
{
    [TestClass]
    public class DadoUmChamado
    {
        private Chamado chamado;
        private ICalculateDate calculateDate;

        [TestInitialize]
        public void Setup()
        {
            chamado = new Chamado("Chamado de Teste", "Esse é um chamado de Teste", 1, 2);
            calculateDate = new CalculateDate();
        }

        [TestMethod]
        public void AoVerificarSeChamadoFoiFechadoRetornaTrueSeOStatusForResolvido()
        {
            chamado.EncerrarChamado(StatusDoChamado.Resolvido);
            Assert.AreEqual(true, chamado.EstaEncerrado);
        }
        
        [TestMethod]
        public void AoVerificarSeChamadoFoiFechadoRetornaTrueSeOStatusForNaoReproduzido()
        {
            chamado.EncerrarChamado(StatusDoChamado.NaoReproduzido);
            Assert.AreEqual(true, chamado.EstaEncerrado);
        }

        [TestMethod]
        public void PossoVerificarONumeroDeDiasUteis()
        {
            Assert.AreEqual(0, chamado.NumeroDeDiasUteis(calculateDate));
        }

        [TestMethod]
        public void PossoVerificarONumeroDeDiasUteisDoChamadoEncerrado()
        {
            chamado.EncerrarChamado(StatusDoChamado.Resolvido);
            Assert.AreEqual(0, chamado.NumeroDeDiasUteis(calculateDate));
        }

        [TestMethod]
        public void PossoReabrirChamado()
        {
            chamado.ReabrirChamado();
            Assert.AreEqual(StatusDoChamado.Reaberto, chamado.StatusDoChamado);
        }

        [TestMethod]
        public void AoReabrirChamadoDataDeEncerramentoSeTornaNula()
        {
            chamado.ReabrirChamado();
            Assert.AreEqual(null, chamado.DataDeEncerramento);
        }

        //[TestMethod, ExpectedException(typeof(ChamadosException))]
        //public void AoAssociarAnalistaAoChamadoSeOUsuarioInformadoNaoForAnalistaGeraException()
        //{
        //    var usuarioNaoAnalista = new Usuario("teste@naoanalista.com", "Nao Analista", TipoUsuario.Comum);
        //    chamado.AssociarAnalista(usuarioNaoAnalista);
        //}

        //[TestMethod]
        //public void AssociarAnalistaAoChamadoSeOTipoDeleForAnalista()
        //{
        //    var usuarioAnalista = new Usuario("teste@analista.com", "Analista", TipoUsuario.Analista);
        //    chamado.AssociarAnalista(usuarioAnalista);
        //}
    }
}
