using System.Collections.Generic;
using AutoMapper;
using SistemaDeChamados.Application.Interface;
using SistemaDeChamados.Application.ViewModels;
using SistemaDeChamados.Domain.Entities;
using SistemaDeChamados.Domain.Interfaces.Services;

namespace SistemaDeChamados.Application.AppServices
{
    public class PerfilAppService : IPerfilAppService
    {
        private readonly IPerfilService perfilService;

        public PerfilAppService(IPerfilService perfilService)
        {
            this.perfilService = perfilService;
        }

        public void Create(PerfilVM model)
        {
            var perfil = Mapper.Map<Perfil>(model);
            perfilService.Create(perfil);
        }

        public void Editar(PerfilVM perfil)
        {
            perfilService.Update(Mapper.Map<Perfil>(perfil));
        }

        public IEnumerable<PerfilVM> Listar()
        {
            return Mapper.Map<IEnumerable<PerfilVM>>(perfilService.Retrieve());
        }
    }
}
