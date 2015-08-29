using System.Collections.Generic;
using System.Threading.Tasks;
using SistemaDeChamados.Domain.DTO;
using SistemaDeChamados.Domain.Interfaces.Repositories;
using SistemaDeChamados.Domain.Interfaces.Services;

namespace SistemaDeChamados.Domain.Services
{
    public class ColaboradorService : UsuarioService, IColaboradorService
    {
        private readonly IColaboradorRepository colaboradorRepository;

        public ColaboradorService(IColaboradorRepository colaboradorRepository,IUsuarioRepository usuarioRepository, ICriptografadorDeSenha criptografadorDeSenha) : base(usuarioRepository, criptografadorDeSenha)
        {
            this.colaboradorRepository = colaboradorRepository;
        }

        public async Task<IList<ColaboradorDTO>> ObterAtivosAsync()
        {
            return await colaboradorRepository.ObterAtivosAsync();
        }
        
        public async Task<IList<ColaboradorDTO>> ObterAsync()
        {
            return await colaboradorRepository.ObterAsync();
        }
        
        public UsuarioDTO ObterParaEdicao(long id)
        {
            return colaboradorRepository.ObterParaEdicao(id);
        }

        public string ObterNomeDoColaboradorPorId(long id)
        {
            return colaboradorRepository.ObterNomeDoColaboradorPorId(id);
        }
    }
}
