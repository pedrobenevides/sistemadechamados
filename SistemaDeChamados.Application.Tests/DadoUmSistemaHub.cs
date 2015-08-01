using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using SistemaDeChamados.Application.Interface.Socket;
using SistemaDeChamados.Application.SignalR;

namespace SistemaDeChamados.Application.Tests
{
    [TestClass]
    public class DadoUmSistemaHub
    {
        private ISistemaHub sistemaHub;

        [TestInitialize]
        public void Setup()
        {
            sistemaHub = new SistemaHub()
            {
                Clients = Substitute.For<IHubCallerConnectionContext<dynamic>>(),
                Groups = Substitute.For<IGroupManager>(),
                Context = Substitute.For<HubCallerContext>()
            };
        }

        [TestMethod]
        public void PossoAdicionarAoGrupoNaoLancaException()
        {
            sistemaHub.AdicionarAoGrupo("Teste");
        }

        [TestMethod]
        public void AoComunicarPeloHubNaoLancaException()
        {
            sistemaHub.Comunicar("Teste","Testando");
        }
    }
}
