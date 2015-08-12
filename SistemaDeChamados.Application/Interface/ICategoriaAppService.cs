using System.Collections.Generic;
using SistemaDeChamados.Domain.Entities;

namespace SistemaDeChamados.Application.Interface
{
    public interface ICategoriaAppService
    {
        IEnumerable<Categoria> ObterTodasCategorias();
    }
}
