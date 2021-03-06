﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using NSubstitute.ReturnsExtensions;
using SistemaDeChamados.Domain.DTO;
using SistemaDeChamados.Domain.Entities;
using SistemaDeChamados.Domain.Enums;
using SistemaDeChamados.Domain.Exceptions;
using SistemaDeChamados.Domain.Exceptions.Usuario;
using SistemaDeChamados.Domain.Interfaces.Repositories;
using SistemaDeChamados.Domain.Interfaces.Services;
using SistemaDeChamados.Domain.Services;

namespace SistemaDeChamados.Domain.Tests.ServicesTest
{
    [TestClass]
    public class DadoUmUsuarioService
    {
        private IUsuarioService usuarioService;
        private IUsuarioRepository usuarioRepository;
        private ICriptografadorDeSenha criptografadorDeSenha;

        [TestInitialize]
        public void Setup()
        {
            usuarioRepository = Substitute.For<IUsuarioRepository>();
            criptografadorDeSenha = Substitute.For<ICriptografadorDeSenha>();
            usuarioService = new UsuarioService(usuarioRepository, criptografadorDeSenha);
        }

        [TestMethod, ExpectedException(typeof(ServiceException))]
        public void ThrowExceptionSeOLoginInformadoNaoPertencerANenhumUsuario()
        {
            const string email = "teste@mail.com";
            usuarioRepository.ObterAtivoPorEmail(email).ReturnsNull();
            usuarioService.ValidaSenhaInformada(email, "123456");
        }

        [TestMethod, ExpectedException(typeof(ServiceException))]
        public void ThrowExceptionSeASenhaInformadaNaoForAMesmaQueOUsuarioPossuiNoBanco()
        {
            const string email = "teste@mail.com";
            usuarioRepository.ObterAtivoPorEmail(email).Returns(new Colaborador(email, "Pedro", 1));
            usuarioService.ValidaSenhaInformada(email, "123456");
        }

        [TestMethod, ExpectedException(typeof(UsuarioNaoEncontradoException))]
        public void AoAlterarStatusDoUsuarioSeNaoExistirUsuarioComEsseIdLancaUsuarioNaoEncontradoException()
        {
            usuarioService.AlterarStatus(1);
        }

        [TestMethod]
        public void AlteraStatusParaTrueSeStatusEstiverFalse()
        {
            var usuario = new Colaborador("teste@mail.com", "Fulano", 1);
            usuario.DesativarUsuario();

            usuarioRepository.GetByIdAsNoTracking(1).Returns(usuario);
            usuarioService.AlterarStatus(1);

            usuarioRepository.Received().Update(usuario);
        }

        [TestMethod]
        public void AlteraStatusParaFalseSeStatusEstiverTrue()
        {
            var usuario = new Colaborador("teste@mail.com", "Fulano", 1);
            usuario.AtivarUsuario();

            usuarioRepository.GetByIdAsNoTracking(1).Returns(usuario);
            usuarioService.AlterarStatus(1);

            usuarioRepository.Received().Update(usuario);
        }

        [TestMethod]
        public void ConsigoAtualizarSenha()
        {
            var usuario = new UsuarioSenhaDTO { Id = 1, Password = "123456" };
            usuarioRepository.GetById(1).Returns(new Colaborador("teste@mail.com", "Fulano", 1));

            usuarioService.AtualizarSenha(usuario);
        }
    }
}
