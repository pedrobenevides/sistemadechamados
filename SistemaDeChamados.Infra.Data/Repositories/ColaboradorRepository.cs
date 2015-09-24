using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using SistemaDeChamados.Domain.DTO;
using SistemaDeChamados.Domain.Interfaces.Repositories;

namespace SistemaDeChamados.Infra.Data.Repositories
{
    public class ColaboradorRepository : UsuarioRepository, IColaboradorRepository
    {
        public async Task<IList<ColaboradorDTO>> ObterAtivosAsync()
        {
            return await context.Colaboradores.Where(c => c.EstaAtivo).Select(c => new ColaboradorDTO
            {
                Email = c.Email,
                EstaAtivo = c.EstaAtivo,
                Id = c.Id,
                Nome = c.Nome,
                Senha = c.Password
            }).ToListAsync();
        }
        public async Task<IList<ColaboradorDTO>> ObterAsync()
        {
            return await context.Colaboradores.Select(c => new ColaboradorDTO
            {
                Email = c.Email,
                EstaAtivo = c.EstaAtivo,
                Id = c.Id,
                Nome = c.Nome,
                Senha = c.Password
            })
            .OrderBy(c => c.Nome).ToListAsync();
        }
        public UsuarioDTO ObterParaEdicao(long id)
        {
            return context.Colaboradores.Where(u => u.Id == id).Select(u => new UsuarioDTO
            { 
                Email = u.Email, 
                Nome = u.Nome, 
                SetorId = u.SetorId, 
                PerfilId = u.PerfilId,
                EstaAtivo = u.EstaAtivo
            
            }).FirstOrDefault();
        }

        public string ObterNomeDoColaboradorPorId(long id)
        {
            return context.Colaboradores.Where(c => c.Id == id).Select(c => c.Nome).FirstOrDefault();
        }

        public async Task<IEnumerable<ColaboradorDTO>> ObterAsyncPaginado(int pagina, int porPagina)
        {
            var skip = ((pagina - 1)*porPagina);
            return await context.Colaboradores.Select(c => new ColaboradorDTO
            {
                Email = c.Email,
                EstaAtivo = c.EstaAtivo,
                Id = c.Id,
                Nome = c.Nome,
                Senha = c.Password
            })
           .OrderBy(c => c.Nome).Skip(skip).Take(porPagina).ToListAsync();
        }
    }

}
