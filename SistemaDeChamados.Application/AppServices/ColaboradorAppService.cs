using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using SistemaDeChamados.Application.Interface;
using SistemaDeChamados.Application.Interface.Services;
using SistemaDeChamados.Application.ViewModels;
using SistemaDeChamados.Domain.DTO;
using SistemaDeChamados.Domain.Entities;
using SistemaDeChamados.Domain.Exceptions;
using SistemaDeChamados.Domain.Interfaces.Services;

namespace SistemaDeChamados.Application.AppServices
{
    public class ColaboradorAppService : UsuarioAppService, IColaboradorAppService
    {
        private readonly IColaboradorService colaboradorService;

        public ColaboradorAppService(IColaboradorService colaboradorService,IUsuarioService usuarioService, IPerfilService perfilService, IServiceLocator serviceLocator)
            : base(usuarioService, perfilService, serviceLocator)
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
            var colaboradores = colaboradorService.Obter();
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
            var colaboradoExistenteNoBanco = colaboradorService.GetById(colaboradorVM.Id) as Colaborador;

            if(colaboradoExistenteNoBanco == null)
                throw new ChamadosException("Usuário inexistente, ou inválido.");

            var colaborador = Mapper.Map(colaboradorVM, colaboradoExistenteNoBanco);

            BeginTransaction();
            colaboradorService.Update(colaborador);
            Commit();
        }

        public ColaboradorEdicaoVM ObterParaEdicao(long id)
        {
            var usuario = colaboradorService.ObterParaEdicao(id);
            return Mapper.Map<UsuarioDTO, ColaboradorEdicaoVM>(usuario);
        }

        public string ObterNomeDoColaboradorPorId(long id)
        {
            return colaboradorService.ObterNomeDoColaboradorPorId(id);
        }

        public async Task<IEnumerable<ColaboradorVM>> ObterAsyncPaginado(int pagina, int porPagina)
        {
            var colaboradores = await colaboradorService.ObterAsyncPaginado(pagina, porPagina);
            return await Task.Run(() => Mapper.Map<IList<ColaboradorVM>>(colaboradores));
        }
    }
}
