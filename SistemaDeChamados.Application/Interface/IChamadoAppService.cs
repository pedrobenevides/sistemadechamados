using System.Collections.Generic;
using System.Threading.Tasks;
using SistemaDeChamados.Application.ViewModels;

namespace SistemaDeChamados.Application.Interface
{
    public interface IChamadoAppService
    {
        void Create(CriacaoChamadoVM chamadoVM);
        IEnumerable<ChamadoIndexVM> Retrieve();
        void Update(ChamadoVM chamadoVM);
        void Delete(long id);
        ChamadoVM GetById(long id);
        Task<IList<ChamadoIndexVM>> Obter5RecentesPorUsuarioAsync(long usuarioId);
    }
}
