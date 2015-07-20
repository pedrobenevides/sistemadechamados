using System.ComponentModel.DataAnnotations;

namespace SistemaDeChamados.Application.ViewModels
{
    public class UsuarioEdicaoVM
    {
        [ScaffoldColumn(false)]
        public long Id { get; set; }
        [Required(ErrorMessage = "O e-mail do Usuário é obrigatório"), StringLength(50), DataType(DataType.EmailAddress), Display(Name = "E-mail")]
        public string Email { get; set; }
        [Required(ErrorMessage = "O nome do Usuário é obrigatório"), StringLength(100)]
        public string Nome { get; set; }

        public string EmailAntigo { get; set; }
    }
}