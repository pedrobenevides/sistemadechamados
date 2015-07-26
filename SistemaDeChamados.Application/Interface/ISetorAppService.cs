using SistemaDeChamados.Application.ViewModels;

namespace SistemaDeChamados.Application.Interface
{
    public interface ISetorAppService
    {
        SetorVM ObterPorUsuarioId(long usuarioId);
    }
}
