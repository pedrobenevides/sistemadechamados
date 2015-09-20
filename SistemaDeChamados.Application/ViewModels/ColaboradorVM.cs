using System.ComponentModel.DataAnnotations;
using SistemaDeChamados.Domain.Entities;
using SistemaDeChamados.Domain.Enums;

namespace SistemaDeChamados.Application.ViewModels
{
    public class ColaboradorVM
    {
        [ScaffoldColumn(false)]
        public long Id { get; set; }
        [Required(ErrorMessage = "O e-mail do Usuário é obrigatório"), StringLength(50), DataType(DataType.EmailAddress), Display(Name = "E-mail")]
        public string Email { get; set; }
        [Required(ErrorMessage = "O nome do Usuário é obrigatório"), StringLength(100)]
        public string Nome { get; set; }
        [Required, DataType(DataType.Password), Display(Name = "Senha")]
        public string Password { get; set; }
        [Required, DataType(DataType.Password), Compare("Password"), Display(Name = "Confirmação de Senha")]
        public string ConfirmacaoPassword { get; set; }
        public bool EstaAtivo { get; set; }
        [Display(Name = "Setor")]
        public long SetorId { get; set; }
        [Display(Name = "Perfil")]
        public long PerfilId { get; set; }
        public string StatusAtual { get { return EstaAtivo ? "Ativo" : "Desativo"; } }
    }

    public class ColaboradorEdicaoVM
    {
        public long Id { get; set; }
        [Required(ErrorMessage = "O e-mail do Usuário é obrigatório"), StringLength(50), DataType(DataType.EmailAddress), Display(Name = "E-mail")]
        public string Email { get; set; }
        [Required(ErrorMessage = "O nome do Usuário é obrigatório"), StringLength(100)]
        public string Nome { get; set; }
        public bool EstaAtivo { get; set; }
        [Display(Name = "Setor")]
        public long SetorId { get; set; }
        [Display(Name = "Perfil")]
        public long PerfilId { get; set; }
    }

    public class UsuarioLogadoVM
    {
        public long Id { get; set; }
        public string Email { get; set; }
        public string Nome { get; set; }
        public string Setor { get; set; }
        public string Categoria { get; set; }
        public Perfil Perfil { get; set; }
        public TipoUsuario TipoUsuario { get; set; }
    }

    public class UsuarioEdicaoSenhaVM
    {
        public long Id { get; set; }
        public string Senha { get; set; }
        public string ConfirmacaoSenha { get; set; }
    }
}
