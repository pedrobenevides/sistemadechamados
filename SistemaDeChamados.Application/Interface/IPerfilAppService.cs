using System.Collections.Generic;
using SistemaDeChamados.Application.ViewModels;

namespace SistemaDeChamados.Application.Interface
{
    public interface IPerfilAppService
    {
        void Create(PerfilVM model);
        void Editar(PerfilVM perfil);
        IEnumerable<PerfilVM> Listar();
        IList<AcessoVM> ListarAcoesDoSistema();
    }
}
