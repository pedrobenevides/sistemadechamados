 namespace SistemaDeChamados.Application.Interface.Services
{
    public interface IServiceLocator
    {
        T GetInstance<T>();
    }
}
