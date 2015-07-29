using System.Collections.Generic;
using SistemaDeChamados.Domain.Entities;
using SistemaDeChamados.Domain.VO;

namespace SistemaDeChamados.Domain.Interfaces.Services
{
    public interface IPerfilService : IServiceBase<Perfil>
    {
        IEnumerable<AcessoVO> TodosAcessosDePerfil();
    }
}
