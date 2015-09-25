using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Web;

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
        [DisplayName("Criado Em")]
        public DateTime DataDeCriacao { get; set; }
        public string Titulo { get; set; }
        [DisplayName("Criado por")]
        public string NomeDoColaborador { get; set; }
        [DisplayName("Analista")]
        public string NomeDoAnalista { get; set; }
        [DisplayName("Dias Úteis")]
        public int DiasEmAberto { get; set; }
    }

    public class CriacaoChamadoVM
    {
        public CriacaoChamadoVM()
        {
            Anexos = new List<HttpPostedFileBase>();
        }

        public string Titulo { get; set; }
        [DisplayName("Descrição")]
        public string Descricao { get; set; }
        public long UsuarioId { get; set; }
        [DisplayName("Categorias")]
        public long CategoriaId { get; set; }
        [DisplayName("Setores")]
        public long SetorId { get; set; }
        public IList<ArquivoVM> ArquivosStream { get; set; }
        public IList<HttpPostedFileBase> Anexos { get; set; }
    }
}
