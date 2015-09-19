 using System.Collections.Generic;
 using SistemaDeChamados.Domain.DTO;

namespace SistemaDeChamados.Application.ViewModels
{
    public class HomeVM
    {
        public HomeVM()
        {
            ChamadosAtualizados = new List<CommonDTO>();
            ChamadosEmAberto = new List<CommonDTO>();
        }

        public IEnumerable<CommonDTO> ChamadosAtualizados { get; set; }
        public IEnumerable<CommonDTO> ChamadosEmAberto { get; set; }

    }
}
