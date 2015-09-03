 namespace SistemaDeChamados.Application.Interface
{
    public interface IAnalistaAppService : IAppService
    {
        string ObterNomePorId(long id);
    }
}
