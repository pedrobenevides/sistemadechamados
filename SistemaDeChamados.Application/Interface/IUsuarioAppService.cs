using System.Collections.Generic;
using SistemaDeChamados.Application.ViewModels;

namespace SistemaDeChamados.Application.Interface
{
    public interface IUsuarioAppService
    {
        IEnumerable<ColaboradorVM> Retrieve();
        void Delete(long id);
        ColaboradorVM GetById(long id);
        IEnumerable<ColaboradorVM> ObterReadOnly();
        UsuarioLogadoVM ObterUsuarioLogado(LoginVM loginVM);
        void AlterarStatus(long id);
        void AtualizarSenha(ColaboradorVM colaborador);

    }
}
