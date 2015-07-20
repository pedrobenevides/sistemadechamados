using System.Collections.Generic;
using SistemaDeChamados.Application.ViewModels;

namespace SistemaDeChamados.Application.Interface
{
    public interface IUsuarioAppService
    {
        long Create(UsuarioVM usuarioVM);
        IEnumerable<UsuarioVM> Retrieve();
        void Update(UsuarioEdicaoVM usuarioVM);
        void Delete(long id);
        UsuarioVM GetById(long id);
        IEnumerable<UsuarioVM> ObterReadOnly();
        UsuarioEdicaoVM ObterParaEdicao(long id);
        bool ValidarCredenciais(string login, string senha);
    }
}
