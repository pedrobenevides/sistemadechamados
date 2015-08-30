using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using SistemaDeChamados.Application.Interface;
using SistemaDeChamados.Application.ViewModels;
using SistemaDeChamados.Domain.Entities;
using SistemaDeChamados.Domain.Interfaces.Services;

namespace SistemaDeChamados.Application.AppServices
{
    public class PerfilAppService : AppService, IPerfilAppService
    {
        private readonly IPerfilService perfilService;

        public PerfilAppService(IPerfilService perfilService)
        {
            this.perfilService = perfilService;
        }

        public void Create(PerfilVM model)
        {
            var perfil = Mapper.Map<Perfil>(model);
            BeginTransaction();
            perfilService.Create(perfil);
            Commit();
        }

        public void Editar(PerfilVM perfil)
        {
            BeginTransaction();
            perfilService.Update(Mapper.Map<Perfil>(perfil));
            Commit();
        }

        public IEnumerable<PerfilVM> Listar()
        {
            return Mapper.Map<IEnumerable<PerfilVM>>(perfilService.Obter());
        }

        public IList<AcessoVM> ListarAcoesDoSistema()
        {
            return perfilService.TodosAcessosDePerfil().Select(a => new AcessoVM{ Chave = a.Chave, Descricao = a.Descricao}).ToList();
        }
    }
}
