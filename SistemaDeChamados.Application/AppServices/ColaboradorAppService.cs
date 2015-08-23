using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using SistemaDeChamados.Application.Interface;
using SistemaDeChamados.Application.ViewModels;
using SistemaDeChamados.Domain.DTO;
using SistemaDeChamados.Domain.Entities;
using SistemaDeChamados.Domain.Interfaces.Services;

namespace SistemaDeChamados.Application.AppServices
{
    public class ColaboradorAppService : UsuarioAppService, IColaboradorAppService
    {
        private readonly IColaboradorService colaboradorService;

        public ColaboradorAppService(IColaboradorService colaboradorService,IUsuarioService usuarioService, IPerfilService perfilService) 
            : base(usuarioService, perfilService)
        {
            this.colaboradorService = colaboradorService;
        }

        public async Task<IList<ColaboradorVM>> ObterAtivosAsync()
        {
            var colaboradores = await colaboradorService.ObterAtivosAsync();
            return await Task.Run(() => Mapper.Map<IList<ColaboradorVM>>(colaboradores));
        }

        public async Task<IList<ColaboradorVM>> ObterAsync()
        {
            var colaboradores = await colaboradorService.ObterAsync();
            return await Task.Run(() => Mapper.Map<IList<ColaboradorVM>>(colaboradores));
        }
        public IList<ColaboradorVM> Obter()
        {
            var colaboradores = colaboradorService.Retrieve();
            return Mapper.Map<IList<ColaboradorVM>>(colaboradores);
        }

        public void Create(ColaboradorVM colaboradorVM)
        {
            var usuario = Mapper.Map<ColaboradorVM, Colaborador>(colaboradorVM);
            BeginTransaction();
            colaboradorService.Create(usuario);
            Commit();
        }
        
        public void Update(ColaboradorEdicaoVM colaboradorVM)
        {
            var usuario = Mapper.Map<ColaboradorEdicaoVM, Colaborador>(colaboradorVM);
            BeginTransaction();
            colaboradorService.Update(usuario);
            Commit();
        }

        public ColaboradorEdicaoVM ObterParaEdicao(long id)
        {
            var usuario = colaboradorService.ObterParaEdicao(id);
            return Mapper.Map<UsuarioDTO, ColaboradorEdicaoVM>(usuario);
        }
    }
}
