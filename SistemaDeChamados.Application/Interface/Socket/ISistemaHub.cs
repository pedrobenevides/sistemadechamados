using System.Threading.Tasks;

namespace SistemaDeChamados.Application.Interface.Socket
{
    public interface ISistemaHub
    {
        Task Comunicar(string nome, string menssagem);
        Task AdicionarAoGrupo(string nomeDoGrupo);
        void AtualizarMsgBadge(int count, string username);
    }
}
