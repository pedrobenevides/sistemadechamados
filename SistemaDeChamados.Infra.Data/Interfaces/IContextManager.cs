using SistemaDeChamados.Infra.Data.Contexto;

namespace SistemaDeChamados.Infra.Data.Interfaces
{
    public interface IContextManager
    {
        SistemaContext GetContext();
    }
}
