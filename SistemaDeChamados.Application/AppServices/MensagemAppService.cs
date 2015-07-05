using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using SistemaDeChamados.Application.Interface;
using SistemaDeChamados.Application.ViewModels;
using SistemaDeChamados.Domain.Entities;
using SistemaDeChamados.Domain.Interfaces.Repositories;
using SistemaDeChamados.Domain.Interfaces.Services;

namespace SistemaDeChamados.Application.AppServices
{
    public class MensagemAppService : IMensagemAppService
    {
        private readonly IMensagemService mensagemService;

        public MensagemAppService(IMensagemService mensagemService)
        {
            this.mensagemService = mensagemService;
        }

        public void Create(MensagemVM mensagemVM)
        {
            var mensagem = Mapper.Map<MensagemVM,Mensagem>(mensagemVM);
            mensagemService.Create(mensagem);
        }

        public IEnumerable<MensagemVM> Retrieve()
        {
            var listaDeMensagens = mensagemService.Retrieve();
            return Mapper.Map<IList<Mensagem>, IList<MensagemVM>>(listaDeMensagens.ToList());
        }

        public void Update(MensagemVM mensagemVM)
        {
            var mensagem = Mapper.Map<MensagemVM, Mensagem>(mensagemVM);
            mensagemService.Update(mensagem);
        }

        public void Delete(long id)
        {
            mensagemService.Delete(id);
        }

        public MensagemVM GetById(long id)
        {
            var mensagem = mensagemService.GetById(id);
            return Mapper.Map<Mensagem, MensagemVM>(mensagem);
        }
    }
}
