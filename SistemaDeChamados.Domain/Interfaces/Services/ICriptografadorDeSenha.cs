namespace SistemaDeChamados.Domain.Interfaces.Services
{
    public interface ICriptografadorDeSenha
    {
        string CriptografarSenha(string senhaPlainText);
    }
}
