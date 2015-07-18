using System;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNet.Identity.EntityFramework;

namespace SistemaDeChamados.Infra.CrossCuting.Identity.Entities
{
    public class UsuarioIdentity : IdentityUser
    {
        public long UsuarioId { get; set; }

        #region NotMapped
        [NotMapped]
        public override bool PhoneNumberConfirmed { get; set; }
        [NotMapped]
        public override string PhoneNumber { get; set; }
        [NotMapped]
        public override DateTime? LockoutEndDateUtc { get; set; }
        [NotMapped]
        public override bool TwoFactorEnabled { get; set; }
        #endregion
    }
}
