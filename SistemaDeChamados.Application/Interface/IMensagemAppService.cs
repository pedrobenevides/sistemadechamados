using System.Collections.Generic;
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
    }
}
