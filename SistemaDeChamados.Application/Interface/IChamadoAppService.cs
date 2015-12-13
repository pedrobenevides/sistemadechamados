using System.Collections.Generic;
using System.Threading.Tasks;
using SistemaDeChamados.Application.ViewModels;
using SistemaDeChamados.Domain.Enums;

namespace SistemaDeChamados.Application.Interface
{
    public interface IChamadoAppService
    {
        Task CreateAsync(CriacaoChamadoVM chamadoVM);
        IEnumerable<ChamadoIndexVM> Retrieve();
        VisualizarChamadoVM GetCompleteById(long id);
        void Update(ChamadoVM chamadoVM);
        void Delete(long id);
        ChamadoVM GetById(long id);
        Task<IList<ChamadoIndexVM>> Obter5RecentesPorUsuarioAsync(long usuarioId);
        Task<HomeVM> ObterHomeVMAsync(long usuarioId);
        void AlterarStatus(long chamadoId, long usuarioId, StatusDoChamado statusNovo);
        Task AlterarStatusAsync(long id, long usuarioId, string status);
        long ObterIdDoAnalistaDesseChamado(long chamadoId);
    }
}
