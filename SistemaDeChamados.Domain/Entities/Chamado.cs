using System;
using System.Security.Cryptography.X509Certificates;
using SistemaDeChamados.Domain.Enums;
using SistemaDeChamados.Domain.Interfaces;

namespace SistemaDeChamados.Domain.Entities
{
    public class Chamado
    {
        public long ChamadoId { get; set; }
        public DateTime DataDeCriacao { get; set; }
        public DateTime? DataDeEncerramento { get; set; }
        public DateTime DataDeReabertura { get; set; }
        public string Descricao { get; set; }
        public long UsuarioCriador { get; set; }
        public StatusDoChamado StatusDoChamado { get; set; }

        public bool OChamadoEstaEncerrado()
        {
            return StatusDoChamado == StatusDoChamado.NaoReproduzido || StatusDoChamado == StatusDoChamado.Resolvido;
        }
        
        public int NumeroDeDiasUteis(ICalculateDate calculateDate)
        {
            return DataDeEncerramento.HasValue && OChamadoEstaEncerrado() 
                ? calculateDate.CalculateBusinessDays(DataDeCriacao, DataDeEncerramento.Value)
                :calculateDate.CalculateBusinessDays(DataDeCriacao, DateTime.Now);
        }
    }
}
