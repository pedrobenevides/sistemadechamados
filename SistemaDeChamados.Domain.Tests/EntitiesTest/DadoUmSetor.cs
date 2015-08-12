using Microsoft.VisualStudio.TestTools.UnitTesting;
using SistemaDeChamados.Domain.Entities;
using SistemaDeChamados.Domain.Enums;
using SistemaDeChamados.Domain.Exceptions.Usuario;

namespace SistemaDeChamados.Domain.Tests.EntitiesTest
{
    [TestClass]
    public class DadoUmSetor
    {
        private Setor setor;

        [TestInitialize]
        public void Inicio()
        {
            setor = new Setor("Financeiro");
        }

        [TestMethod]
        public void AoInstanciarUmSetorListaDeUsuarioNaoEhNula()
        {
            var setorNovo = new Setor("Setor de Teste");
            Assert.AreNotEqual(null, setorNovo.Usuarios);
        }

        [TestMethod]
        public void PossoAdicionarUmUsuarioDaListaDeUsuariosDoSetor()
        {
            setor.AdicionarUsuario(new Usuario("fin@mail.com", "Joao Silva", TipoUsuario.Comum));
            Assert.AreEqual(1, setor.Usuarios.Count);
        }

        [TestMethod]
        public void PossoRemoverUmUsuarioDaListaDeUsuariosDoSetor()
        {
            setor.AdicionarUsuario(new Usuario("fin@mail.com", "Joao Silva", TipoUsuario.Comum));
            setor.RemoverUsuario(0);
            Assert.AreEqual(0, setor.Usuarios.Count);
        }

        [TestMethod, ExpectedException(typeof(UsuarioNaoEncontradoException))]
        public void LancaExceptionAoTentarRemoverUsuarioComIdQueNaoEstaNaLista()
        {
            setor.RemoverUsuario(11);
        }

    }
}
