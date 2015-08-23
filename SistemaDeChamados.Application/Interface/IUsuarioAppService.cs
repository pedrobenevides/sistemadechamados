using System.Collections.Generic;
using SistemaDeChamados.Application.ViewModels;

namespace SistemaDeChamados.Application.Interface
{
    public interface IUsuarioAppService
    {
        void Create(UsuarioVM usuarioVM);
        IEnumerable<UsuarioVM> Retrieve();
        void Update(UsuarioVM usuarioVM);
        void Delete(long id);
        UsuarioVM GetById(long id);
        IEnumerable<UsuarioVM> ObterReadOnly();
        UsuarioVM ObterParaEdicao(long id);
        UsuarioLogadoVM ObterUsuarioLogado(LoginVM loginVM);
        void AlterarStatus(long id);
        void AtualizarSenha(UsuarioVM usuario);

    }
}
