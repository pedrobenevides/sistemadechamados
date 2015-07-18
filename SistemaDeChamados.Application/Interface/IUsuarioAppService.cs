using System.Collections.Generic;
using SistemaDeChamados.Application.ViewModels;

namespace SistemaDeChamados.Application.Interface
{
    public interface IUsuarioAppService
    {
        long Create(UsuarioVM usuarioVM);
        IEnumerable<UsuarioVM> Retrieve();
        void Update(UsuarioVM usuarioVM);
        void Delete(long id);
        UsuarioVM GetById(long id);
        IEnumerable<UsuarioVM> ObterReadOnly();
        UsuarioVM ObterParaEdicao(long id);
        bool ValidarCredenciais(string login, string senha);
    }
}
