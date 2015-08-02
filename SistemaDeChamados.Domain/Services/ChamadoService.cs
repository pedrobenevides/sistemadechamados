using SistemaDeChamados.Domain.Entities;
using SistemaDeChamados.Domain.Interfaces.Repositories;
using SistemaDeChamados.Domain.Interfaces.Services;

namespace SistemaDeChamados.Domain.Services
{
    public class ChamadoService : ServiceBase<Chamado>,  IChamadoService
    {
        private readonly IChamadoRepository chamadoRepository;

        public ChamadoService(IChamadoRepository chamadoRepository) 
            : base(chamadoRepository)
        {
            this.chamadoRepository = chamadoRepository;
        }
    }
}
