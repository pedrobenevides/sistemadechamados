using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.Practices.ServiceLocation;
using SistemaDeChamados.Application.Interface;
using SistemaDeChamados.Application.ViewModels;
using SistemaDeChamados.Domain.Entities;

namespace SistemaDeChamados.Application.AutoMapper.CustomMaps
{
    public class MensagemMapper : Profile
    {
        private readonly IUsuarioAppService usuarioAppService;
        public IDictionary<long, string> Nomes { get; set; }

        public MensagemMapper()
        {
            usuarioAppService = ServiceLocator.Current.GetInstance<IUsuarioAppService>();
            Nomes = new Dictionary<long, string>();
        }

        protected override void Configure()
        {
            Mapper.CreateMap<Mensagem, MensagemVM>()
                .ForMember(vm => vm.FoiLida, exp => exp.ResolveUsing(VerificarSeMensagemJaFoiLida))
                .ForMember(vm => vm.NomeUsuario, exp => exp.ResolveUsing(ObterNomeDeUsuario));

            Mapper.CreateMap<Task<IEnumerable<Mensagem>>, Task<IEnumerable<MensagemVM>>>();
        }

        private object ObterNomeDeUsuario(Mensagem msg)
        {
            var nomeNoDicionario = Nomes.FirstOrDefault(n => n.Key == msg.UsuarioId);

            if (!string.IsNullOrEmpty(nomeNoDicionario.Value))
                return nomeNoDicionario.Value;

            var usuario = usuarioAppService.GetById(msg.UsuarioId);
            Nomes.Add(usuario.Id, usuario.Nome);

            return usuario.Nome;
        }

        private static object VerificarSeMensagemJaFoiLida(Mensagem msg)
        {
            return msg.DataDaLeitura.HasValue;
        }

    }
}
