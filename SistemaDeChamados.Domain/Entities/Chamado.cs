using System;
using System.Collections.Generic;
using SistemaDeChamados.Domain.Enums;
using SistemaDeChamados.Domain.Interfaces;

namespace SistemaDeChamados.Domain.Entities
{
    public class Chamado
    {
        public long Id { get; set; }
        public DateTime DataDeCriacao { get; set; }
        public DateTime? DataDeEncerramento { get; set; }
        public DateTime DataDeReabertura { get; set; }
        public string Descricao { get; set; }
        public long UsuarioCriadorId { get; set; }
        public StatusDoChamado StatusDoChamado { get; set; }
        public string Titulo { get; set; }
        public virtual Usuario UsuarioCriador { get; set; }
        public virtual IList<Mensagem> Mensagens { get; set; }
        public bool EstaEncerrado
        {
            get { return StatusDoChamado == StatusDoChamado.NaoReproduzido || StatusDoChamado == StatusDoChamado.Resolvido; }
        }
        
        public int NumeroDeDiasUteis(ICalculateDate calculateDate)
        {
            return DataDeEncerramento.HasValue && EstaEncerrado 
                ? calculateDate.CalculateBusinessDays(DataDeCriacao, DataDeEncerramento.Value)
                :calculateDate.CalculateBusinessDays(DataDeCriacao, DateTime.Now);
        }
    }
}
