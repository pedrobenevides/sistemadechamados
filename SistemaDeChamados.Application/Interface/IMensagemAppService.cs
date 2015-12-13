using System.Collections.Generic;
using System.Threading.Tasks;
using SistemaDeChamados.Application.ViewModels;

namespace SistemaDeChamados.Application.Interface
{
    public interface IMensagemAppService
    {
        void Create(MensagemVM mensagemVM);
        IEnumerable<MensagemVM> Retrieve();
        void Update(MensagemVM mensagemVM);
        void Delete(long id);
        MensagemVM GetById(long id);
        Task<IEnumerable<MensagemVM>> Obter5UltimasAsync(long chamadoId);
        IEnumerable<MensagemVM> Obter5Ultimas(long chamadoId);
        int ObterNumeroDeMensagensNaoLidas(long usuarioId);
    }
}
