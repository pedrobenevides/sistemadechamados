using System.Collections.Generic;
using System.Threading.Tasks;
using SistemaDeChamados.Domain.DTO;
using SistemaDeChamados.Domain.Entities;

namespace SistemaDeChamados.Application.Interface
{
    public interface ICategoriaAppService
    {
        IEnumerable<Categoria> ObterTodasCategorias();
        IEnumerable<CommonDTO> ObterPorSetor(long setorId);
        Task<IEnumerable<Categoria>> ObterPorSetorAsync(long setorId);
    }
}
