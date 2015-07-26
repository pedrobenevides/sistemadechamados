using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using SistemaDeChamados.Domain.Interfaces.Repositories;
using SistemaDeChamados.Domain.Interfaces.Services;
using SistemaDeChamados.Domain.Services;

namespace SistemaDeChamados.Domain.Tests
{
    [TestClass]
    public class DadoUmSetorService
    {
        private ISetorService setorService;
        private ISetorRepository setorRepository;

        [TestInitialize]
        public void Setup()
        {
            setorRepository = Substitute.For<ISetorRepository>();
            setorService = new SetorService(setorRepository);
        }

        [TestMethod]
        public void AoObterSetorPorUsuarioIdDeveChamarMesmoMetodoNoRepositorio()
        {
            setorService.ObterPorUsuarioId(1);
            setorRepository.Received().ObterPorUsuarioId(1);
        }
    }
}
