using System.Collections.Generic;
using AutoMapper;
using SistemaDeChamados.Application.Interface;
using SistemaDeChamados.Application.ViewModels;
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
    }
}
