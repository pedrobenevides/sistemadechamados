using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using SistemaDeChamados.Application.Interface;
using SistemaDeChamados.Application.ViewModels;
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

        public async Task<IList<UsuarioVM>> ObterAtivosAsync()
        {
            var colaboradores = await colaboradorService.ObterAtivosAsync();
            return await Task.Run(() => Mapper.Map<IList<UsuarioVM>>(colaboradores));
        }
    }
}
