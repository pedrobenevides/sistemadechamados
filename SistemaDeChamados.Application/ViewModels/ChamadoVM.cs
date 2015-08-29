using System;
using System.ComponentModel;

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

    public class ChamadoIndexVM
    {
        public long Id { get; set; }
        public DateTime DataDeCriacao { get; set; }
        public string Titulo { get; set; }
        public string NomeDoColaborador { get; set; }
        public string NomeDoAnalista { get; set; }
        public int DiasEmAberto { get; set; }
    }

    public class CriacaoChamadoVM
    {
        public string Titulo { get; set; }
        [DisplayName("Descrição")]
        public string Descricao { get; set; }
        public long UsuarioId { get; set; }
        [DisplayName("Categorias")]
        public long CategoriaId { get; set; }
        [DisplayName("Setores")]
        public long SetorId { get; set; }
    }
}
