using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using SistemaDeChamados.Application.Interface;
using SistemaDeChamados.Application.Interface.Services;
using SistemaDeChamados.Application.ViewModels;
using SistemaDeChamados.Domain.Entities;
using SistemaDeChamados.Domain.Interfaces.Services;

namespace SistemaDeChamados.Application.AppServices
{
    public class MensagemAppService : AppService, IMensagemAppService
    {
        private readonly IMensagemService mensagemService;

        public MensagemAppService(IMensagemService mensagemService, IServiceLocator serviceLocator)
            : base(serviceLocator)
        {
            this.mensagemService = mensagemService;
        }

        public void Create(MensagemVM mensagemVM)
        {
            var mensagem = Mapper.Map<MensagemVM,Mensagem>(mensagemVM);
            BeginTransaction();
            mensagemService.Create(mensagem);
            Commit();
        }

        public IEnumerable<MensagemVM> Retrieve()
        {
            var listaDeMensagens = mensagemService.Obter();
            return Mapper.Map<IList<Mensagem>, IList<MensagemVM>>(listaDeMensagens.ToList());
        }

        public void Update(MensagemVM mensagemVM)
        {
            var mensagem = Mapper.Map<MensagemVM, Mensagem>(mensagemVM);
            BeginTransaction();
            mensagemService.Update(mensagem);
            Commit();
        }

        public void Delete(long id)
        {
            BeginTransaction();
            mensagemService.Delete(id);
            Commit();
        }

        public MensagemVM GetById(long id)
        {
            var mensagem = mensagemService.GetById(id);
            return Mapper.Map<Mensagem, MensagemVM>(mensagem);
        }

        public async Task<IEnumerable<MensagemVM>> Obter5UltimasAsync(long chamadoId)
        {
            return await Mapper.Map<Task<IEnumerable<MensagemVM>>>(mensagemService.Obter5UltimasAsync(chamadoId));
        }

        public IEnumerable<MensagemVM> Obter5Ultimas(long chamadoId)
        {
            return Mapper.Map<IEnumerable<MensagemVM>>(mensagemService.Obter5Ultimas(chamadoId));
        }

        public int ObterNumeroDeMensagensNaoLidas(long usuarioId)
        {
            return mensagemService.ObterNumeroDeMensagensNaoLidas(usuarioId);
        }
    }
}
