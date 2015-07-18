using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using SistemaDeChamados.Infrastructure.Security.Models;

namespace SistemaDeChamados.Infrastructure.Security
{
    public class IdentityContext : IdentityDbContext<ApplicationUser>
    {
        public IdentityContext()
            : base("ChamadosDb", throwIfV1Schema: false)
        { }

        public IDbSet<Claims> Claims { get; set; }

        public static IdentityContext Create()
        {
            return new IdentityContext();
        }
    }
}
