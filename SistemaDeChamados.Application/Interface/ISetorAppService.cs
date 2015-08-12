using System.Collections.Generic;
using SistemaDeChamados.Application.ViewModels;
using SistemaDeChamados.Domain.Entities;

namespace SistemaDeChamados.Application.Interface
{
    public interface ISetorAppService
    {
        IEnumerable<Setor> ObterTodosOsSetores();
        SetorVM ObterPorUsuarioId(long usuarioId);
        string ObterNomeDoSetorPorId(long setorId);
    }
}
