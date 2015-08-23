using System.Collections.Generic;
using System.Threading.Tasks;
using SistemaDeChamados.Domain.Entities;
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

        public async Task<IList<Colaborador>> ObterAtivosAsync()
        {
            return await colaboradorRepository.ObterAtivosAsync();
        }
    }
}
