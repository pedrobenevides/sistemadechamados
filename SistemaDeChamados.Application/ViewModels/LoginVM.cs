using System.ComponentModel.DataAnnotations;

namespace SistemaDeChamados.Application.ViewModels
{
    public class LoginVM
    {
        [Required, DataType(DataType.EmailAddress)]
        public string Login { get; set; }
        [Required, DataType(DataType.Password)]
        public string Senha { get; set; }
    }
}
