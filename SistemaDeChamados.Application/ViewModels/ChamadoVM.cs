using System;
using System.Collections.Generic;
using System.ComponentModel;
using SistemaDeChamados.Domain.Entities;

namespace SistemaDeChamados.Application.ViewModels
{
    public class ChamadoVM
    {
        public long Id { get; set; }
        public DateTime DataDeCriacao { get; set; }
        public DateTime? DataDeEncerramento { get; set; }
        public DateTime DataDeReabertura { get; set; }
        public string Descricao { get; set; }
        public long UsuarioCriadorId { get; set; }
        public string Titulo { get; set; }
    }

    public class CriacaoChamadoVM
    {
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public long UsuarioId { get; set; }
        [DisplayName("Categorias")]
        public long CategoriaId { get; set; }
        [DisplayName("Setores")]
        public long SetorId { get; set; }
    }
}
