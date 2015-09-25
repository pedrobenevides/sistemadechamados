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
        private IArquivoService arquivoService;
        private Chamado chamado;

        [TestInitialize]
        public virtual void Setup()
        {
            chamadoRepository = Substitute.For<IChamadoRepository>();
            arquivoService = Substitute.For<IArquivoService>();

            chamadoService = new ChamadoService(chamadoRepository, arquivoService);

            chamado = new Chamado("Chamado de Teste", "Teste", 1, 1);
            var categoria = new Categoria("Categoria teste", 1);
            categoria.AssociarAnalista(3);
            chamado.Categoria = categoria;
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
            chamadoRepository.GetById(1).Returns(chamado);
            chamadoService.AlterarStatus(1,3, StatusDoChamado.NaoReproduzido);

            chamadoRepository.Received().AlterarStatus(Arg.Any<Chamado>(), Arg.Any<StatusDoChamado>());
        }

        [TestMethod, ExpectedException(typeof(ChamadosException))]
        public void QuandoUsuarioTentarAlterarUmChamadoQueEleNaoSejaOColaboradorOuOAnalistaGeraExcecao()
        {
            chamadoRepository.GetById(1).Returns(chamado);
            chamadoService.AlterarStatus(1, 13, StatusDoChamado.NaoReproduzido);
        }

        [TestMethod]
        public void AoObter5ChamadosRecentesChamaOMesmoMetodoDoRepositorio()
        {
            chamadoService.Obter5RecentesPorUsuarioAsync(1);
            chamadoRepository.Received().Obter5RecentesPorUsuarioAsync(1);
        }

        [TestMethod]
        public void AoObter5ChamadosEmAbertoChamaOMesmoMetodoDoRepositorio()
        {
            chamadoService.Obter5EmAbertoAsync(1);
            chamadoRepository.Received().Obter5EmAbertoAsync(1);
        }
    }
}
