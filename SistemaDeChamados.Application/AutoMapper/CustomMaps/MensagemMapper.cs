using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using SistemaDeChamados.Application.ViewModels;
using SistemaDeChamados.Domain.Entities;

namespace SistemaDeChamados.Application.AutoMapper.CustomMaps
{
    public class MensagemMapper : Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<Mensagem, MensagemVM>()
                .ForMember(vm => vm.FoiLida, exp => exp.ResolveUsing(VerificarSeMensagemJaFoiLida));

            Mapper.CreateMap<Task<IEnumerable<Mensagem>>, Task<IEnumerable<MensagemVM>>>();
        }

        private static object VerificarSeMensagemJaFoiLida(Mensagem msg)
        {
            return msg.DataDaLeitura.HasValue;
        }
    }
}
