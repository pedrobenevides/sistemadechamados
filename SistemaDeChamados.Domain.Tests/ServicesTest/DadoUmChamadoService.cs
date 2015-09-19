using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using SistemaDeChamados.Domain.Entities;
using SistemaDeChamados.Domain.Enums;
using SistemaDeChamados.Domain.Exceptions;
using SistemaDeChamados.Domain.Interfaces.Repositories;
using SistemaDeChamados.Domain.Interfaces.Services;
using SistemaDeChamados.Domain.Services;

namespace SistemaDeChamados.Domain.Tests.ServicesTest
{
    [TestClass]
    public class DadoUmChamadoService
    {
        private IChamadoService chamadoService;
        private IChamadoRepository chamadoRepository;

        [TestInitialize]
        public virtual void Setup()
        {
            chamadoRepository = Substitute.For<IChamadoRepository>();
            chamadoService = new ChamadoService(chamadoRepository);
        }

        [TestMethod]
        public void PossoAlterarOStatusDoChamadoSeEuForOUsuarioCriador()
        {
            chamadoRepository.GetById(1).Returns(new Chamado("Chamado de Teste", "Teste", 1, 1));
            chamadoService.AlterarStatus(1,1, StatusDoChamado.NaoReproduzido);

            chamadoRepository.Received().AlterarStatus(Arg.Any<Chamado>(), Arg.Any<StatusDoChamado>());
        }

        [TestMethod]
        public void PossoAlterarOStatusDoChamadoSeEuForOAnalistaResponsavel()
        {
            var chamado = new Chamado("Chamado de Teste", "Teste", 1, 1);
            var categoria = new Categoria("Categoria teste", 1);
            categoria.AssociarAnalista(3);
            chamado.Categoria = categoria;

            chamadoRepository.GetById(1).Returns(chamado);
            chamadoService.AlterarStatus(1,3, StatusDoChamado.NaoReproduzido);

            chamadoRepository.Received().AlterarStatus(Arg.Any<Chamado>(), Arg.Any<StatusDoChamado>());
        }

        [TestMethod, ExpectedException(typeof(ChamadosException))]
        public void QuandoUsuarioTentarAlterarUmChamadoQueEleNaoSejaOColaboradorOuOAnalistaGeraExcecao()
        {
            var chamado = new Chamado("Chamado de Teste", "Teste", 1, 1);
            var categoria = new Categoria("Categoria teste", 1);
            categoria.AssociarAnalista(3);
            chamado.Categoria = categoria;

            chamadoRepository.GetById(1).Returns(chamado);
            chamadoService.AlterarStatus(1, 13, StatusDoChamado.NaoReproduzido);
        }
    }
}
