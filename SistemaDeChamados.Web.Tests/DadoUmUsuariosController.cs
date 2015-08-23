using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using SistemaDeChamados.Application.Interface;
using SistemaDeChamados.Application.Interface.Socket;
using SistemaDeChamados.Application.ViewModels;
using SistemaDeChamados.Web.Controllers;

namespace SistemaDeChamados.Web.Tests
{
    [TestClass]
    public class DadoUmUsuariosController
    {
        private UsuariosController usuariosController;
        private IColaboradorAppService usuarioAppService;
        private ISistemaHub sistemaHub;
        private ISetorAppService setorAppService;
        private IPerfilAppService perfilAppService;

        [TestInitialize]
        public void Setup()
        {
            sistemaHub = Substitute.For<ISistemaHub>();
            setorAppService = Substitute.For<ISetorAppService>();
            perfilAppService = Substitute.For<IPerfilAppService>();
            usuarioAppService = Substitute.For<IColaboradorAppService>();

            usuariosController = new UsuariosController(usuarioAppService, sistemaHub, setorAppService, perfilAppService);
        }

        [TestMethod]
        public async Task IndexDeveListarTodosOsUsuariosEPassarParaAView()
        {
            await usuariosController.Index();
            usuarioAppService.Received().ObterAsync();
        }

        [TestMethod]
        public void NovoComChamadaGetDevePassarUmUsuarioViewModelParaAView()
        {
            var result = (ViewResult)usuariosController.Novo();
            Assert.AreEqual(typeof(ColaboradorVM), result.Model.GetType());
        }

        [TestMethod]
        public void AoRealizarUmPostParaAActionNovoDeveChamarOMetodoCreateDoUsuarioAppServiceSeModelIsValid()
        {
            var vm = new ColaboradorVM
            {
                Nome = "Fulano",
                Email = "fulano@mail.com",
                Password = "123456",
                ConfirmacaoPassword = "123456"
            };

            usuariosController.Novo(vm);
            usuarioAppService.Received().Create(vm);
        }

        [TestMethod]
        public void AoRealizarUmPostParaAActionNovoDeveRetornarAViewSeModelIsNotValid()
        {
            var badModel = ObterViewModelInvalido();
            var result = (ViewResult)usuariosController.Novo(badModel);
            Assert.AreEqual(typeof(ColaboradorVM), result.Model.GetType());
        }


        [TestMethod]
        public void EdicaoComChamadaGetDevePopularOViewModelEId()
        {
            const int idProcurado = 1;
            usuarioAppService.ObterParaEdicao(idProcurado).Returns(new ColaboradorEdicaoVM());
            var result = (ViewResult)usuariosController.Edicao(idProcurado);

            Assert.AreEqual(idProcurado, ((ColaboradorEdicaoVM)result.Model).Id);
        }

        //[TestMethod]
        //public void AoRealizarUmPostParaAActionEdicaoDeveRetornarAViewSeModelIsNotValid()
        //{
        //    var badModel = ObterViewModelInvalido();
        //    var result = (ViewResult)usuariosController.Edicao(badModel);
        //    Assert.AreEqual(typeof(ColaboradorVM), result.Model.GetType());
        //}

        [TestMethod]
        public void AoRealizarUmPostParaAActionEdicaoDeveChamarOMetodoCreateDoUsuarioAppServiceSeModelIsValid()
        {
            var vm = new ColaboradorEdicaoVM
            {
                Nome = "Fulano",
                Email = "fulano@mail.com"
            };

            usuariosController.Edicao(vm);
            usuarioAppService.Received().Update(vm);
        }

        [TestMethod]
        public void AoSolicitarAlteracaoDeSenhaDeveRetornarUmUsuarioVMParaAView()
        {
            var vm = new ColaboradorEdicaoVM
            {
                Nome = "Fulano",
                Email = "fulano@mail.com"
            };
            usuarioAppService.ObterParaEdicao(1).Returns(vm);
            var result = (ViewResult)usuariosController.AlterarSenha(1);

            Assert.AreEqual(typeof(ColaboradorVM), result.Model.GetType());
        }

        [TestMethod]
        public void AoAlterarASenhaDeveChamarOMetodoAtualizarSenhaDoAppService()
        {
            var vm = new ColaboradorVM
            {
                Nome = "Fulano",
                Email = "fulano@mail.com",
                Password = "123456",
                ConfirmacaoPassword = "123456"
            };

            usuariosController.AlterarSenha(vm);
            usuarioAppService.Received().AtualizarSenha(vm);
        }

        private ColaboradorVM ObterViewModelInvalido()
        {
            var badModel = new ColaboradorVM();
            var validationContext = new ValidationContext(badModel, null, null);
            var validationResults = new List<ValidationResult>();
            Validator.TryValidateObject(badModel, validationContext, validationResults, true);
            foreach (var validationResult in validationResults)
            {
                usuariosController.ModelState.AddModelError(validationResult.MemberNames.First(), validationResult.ErrorMessage);
            }

            return badModel;
        }

    }
}
