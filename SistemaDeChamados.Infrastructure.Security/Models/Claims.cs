using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaDeChamados.Infrastructure.Security.Models
{
    [Table("AspNetClaims")]
    public class Claims
    {
        [Key]
        public long Id { get; set; }
        public string Name { get; set; }
    }
}