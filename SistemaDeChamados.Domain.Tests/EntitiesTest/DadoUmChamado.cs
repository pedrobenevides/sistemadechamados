using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SistemaDeChamados.Domain.Entities;
using SistemaDeChamados.Domain.Enums;
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
            chamado = new Chamado
            {
                StatusDoChamado = StatusDoChamado.Resolvido,
                DataDeCriacao = new DateTime(2015,06,19)
            };

            calculateDate = new CalculateDate();
        }

        [TestMethod]
        public void AoVerificarSeChamadoFoiFechadoRetornaTrueSeOStatusForResolvido()
        {
            chamado.DataDeEncerramento = new DateTime(2015, 06, 19);
            Assert.AreEqual(true, chamado.EstaEncerrado);
        }
        
        [TestMethod]
        public void AoVerificarSeChamadoFoiFechadoRetornaTrueSeOStatusForNaoReproduzido()
        {
            chamado.DataDeEncerramento = new DateTime(2015, 06, 19);
            chamado.StatusDoChamado = StatusDoChamado.NaoReproduzido;
            Assert.AreEqual(true, chamado.EstaEncerrado);
        }

        [TestMethod]
        public void PossoVerificarONumeroDeDiasUteis()
        {
            chamado.DataDeEncerramento = new DateTime(2015, 07, 03);
            Assert.AreEqual(10, chamado.NumeroDeDiasUteis(calculateDate));
        }

        [TestMethod]
        public void PossoVerificarONumeroDeDiasUteisDoChamadoEncerrado()
        {
            chamado.DataDeEncerramento = new DateTime(2015,06,23);
            Assert.AreEqual(2, chamado.NumeroDeDiasUteis(calculateDate));
        }
    }
}
