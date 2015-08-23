using System;
using System.Collections.Generic;
using SistemaDeChamados.Domain.Enums;
using SistemaDeChamados.Domain.Exceptions;
using SistemaDeChamados.Domain.Interfaces;

namespace SistemaDeChamados.Domain.Entities
{
    public class Chamado
    {
        public Chamado(string titulo, string descricao, long usuarioCriadorId, long usuarioAnalistaId, long categoriaId)
        {
            DataDeCriacao = DateTime.Now;
            Descricao = descricao;
            StatusDoChamado = StatusDoChamado.Aberto;
            Titulo = titulo;
            UsuarioCriadorId = usuarioCriadorId;
            UsuarioAnalistaId = usuarioAnalistaId;
            CategoriaId = categoriaId;
        }
        protected Chamado()
        { }

        public long Id { get; private set; }
        public DateTime DataDeCriacao { get; private set; }
        public DateTime? DataDeEncerramento { get; private set; }
        public DateTime? DataDeReabertura { get; private set; }
        public string Descricao { get; private set; }
        public long UsuarioCriadorId { get; private set; }
        public long UsuarioAnalistaId { get; private set; }
        public long CategoriaId { get; private set; }
        public StatusDoChamado StatusDoChamado { get; private set; }
        public string Titulo { get; private set; }
        public virtual Usuario UsuarioCriador { get; private set; }
        public virtual IList<Mensagem> Mensagens { get; private set; }
        public bool EstaEncerrado
        {
            get { return ((StatusDoChamado == StatusDoChamado.NaoReproduzido || StatusDoChamado == StatusDoChamado.Resolvido) && DataDeEncerramento.HasValue); }
        }
        
        public int NumeroDeDiasUteis(ICalculateDate calculateDate)
        {
            if (DataDeEncerramento.HasValue && EstaEncerrado)
                return calculateDate.CalculateBusinessDays(DataDeCriacao, DataDeEncerramento.Value);

            if (DataDeReabertura.HasValue && !DataDeEncerramento.HasValue)
                return calculateDate.CalculateBusinessDays(DataDeReabertura.Value, DateTime.Now);

            return calculateDate.CalculateBusinessDays(DataDeCriacao, DateTime.Now);
        }

        public void ReabrirChamado()
        {
            DataDeReabertura = DateTime.Now;
            DataDeEncerramento = null;
            StatusDoChamado = StatusDoChamado.Reaberto;
        }

        public void EncerrarChamado(StatusDoChamado statusDoChamado)
        {
            DataDeEncerramento = DateTime.Now;
            StatusDoChamado = statusDoChamado;
        }

        public void AssociarAnalista(Analista usuarioAnalista)
        {
            UsuarioAnalistaId = usuarioAnalista.Id;
        }
    }
}
