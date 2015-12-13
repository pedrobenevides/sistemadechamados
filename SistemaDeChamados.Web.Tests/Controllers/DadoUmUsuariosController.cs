using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using SistemaDeChamados.Application.Interface;
using SistemaDeChamados.Application.Interface.Socket;
using SistemaDeChamados.Application.ViewModels;
using SistemaDeChamados.Web.Controllers;
using TestStack.FluentMVCTesting;

namespace SistemaDeChamados.Web.Tests.Controllers
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
            await usuariosController.IndexAsync();
            usuarioAppService.Received().ObterAsync();
        }

        [TestMethod]
        public void NovoComChamadaGetDevePassarUmUsuarioViewModelParaAView()
        {
            usuariosController.WithCallTo(action => action.Novo())
                .ShouldRenderDefaultView()
                .WithModel<ColaboradorVM>();
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
            var model = new ColaboradorVM();
            
            usuariosController.WithModelErrors()
                .WithCallTo(action => action.Novo(model))
                .ShouldRenderDefaultView()
                .WithModel(model);
        }

        [TestMethod]
        public void EdicaoComChamadaGetDevePopularOViewModelEId()
        {
            const int idProcurado = 1;
            var colaboradorEdicaoVm = new ColaboradorEdicaoVM{Id = 1};
            usuarioAppService.ObterParaEdicao(idProcurado).Returns(colaboradorEdicaoVm);

            usuariosController.WithCallTo(action => action.Edicao(idProcurado))
                .ShouldRenderDefaultView().WithModel(colaboradorEdicaoVm);
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
        public void AoSolicitarAlteracaoDeSenhaDeveRetornarUmColaboradorEdicaoVMParaAView()
        {
            var vm = new ColaboradorEdicaoVM
            {
                Nome = "Fulano",
                Email = "fulano@mail.com"
            };
            
            usuarioAppService.ObterParaEdicao(1).Returns(vm);
            usuariosController.WithCallTo(action => action.AlterarSenha(1))
                .ShouldRenderDefaultView()
                .WithModel(vm);
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
