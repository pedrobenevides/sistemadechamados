using System.Collections.Generic;
using AutoMapper;
using SistemaDeChamados.Application.Interface;
using SistemaDeChamados.Application.ViewModels;
using SistemaDeChamados.Domain.Exceptions;
using SistemaDeChamados.Domain.Interfaces.Services;

namespace SistemaDeChamados.Application.AppServices
{
    public class SetorAppService : AppService, ISetorAppService
    {
        private readonly ISetorService setorService;

        public SetorAppService(ISetorService setorService)
        {
            this.setorService = setorService;
        }

        public IEnumerable<SetorVM> ObterTodosOsSetores()
        {
            return Mapper.Map<IEnumerable<SetorVM>>(setorService.Retrieve());
        }

        public SetorVM ObterPorUsuarioId(long usuarioId)
        {
            var setor = setorService.ObterPorUsuarioId(usuarioId);
            return Mapper.Map<SetorVM>(setor);
        }

        public string ObterNomeDoSetorPorId(long setorId)
        {
            var setor = setorService.GetById(setorId);

            if(setor == null)
                throw new ChamadosException("Setor inexistente.");

            return setor.Nome;
        }
    }
}
