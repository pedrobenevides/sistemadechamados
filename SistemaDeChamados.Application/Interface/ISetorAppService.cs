using System.Collections.Generic;
using SistemaDeChamados.Application.ViewModels;

namespace SistemaDeChamados.Application.Interface
{
    public interface ISetorAppService
    {
        IEnumerable<SetorVM> ObterTodosOsSetores();
        SetorVM ObterPorUsuarioId(long usuarioId);
        string ObterNomeDoSetorPorId(long setorId);
    }
}
