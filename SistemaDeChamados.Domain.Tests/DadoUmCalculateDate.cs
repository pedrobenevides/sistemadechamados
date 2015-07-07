using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SistemaDeChamados.Domain.Interfaces;

namespace SistemaDeChamados.Domain.Tests
{
    [TestClass]
    public class DadoUmCalculateDate
    {
        private ICalculateDate calculateDate;

        [TestInitialize]
        public void Setup()
        {
            calculateDate = new CalculateDate();
        }

        [TestMethod]
        public void SeADataForIgualADeHojeDeveRetornarZero()
        {
            var businessDays = calculateDate.CalculateBusinessDays(DateTime.Now, DateTime.Now);
            Assert.AreEqual(0, businessDays);
        }

        [TestMethod]
        public void SeADataForIgualA01Do7DeveRetornar2DiasUteis()
        {
            var businessDays = calculateDate.CalculateBusinessDays(new DateTime(2015,07,01), new DateTime(2015, 07, 03));
            Assert.AreEqual(2, businessDays);
        }

    }
}
