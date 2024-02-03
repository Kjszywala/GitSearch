using Microsoft.AspNetCore.Identity;

namespace GitSearch.DbServices.Models.Database
{
    public class ApplicationRoleClaim : IdentityRoleClaim<Guid>
    {
        public virtual ApplicationRole? Role { get; set; }
    }
}
