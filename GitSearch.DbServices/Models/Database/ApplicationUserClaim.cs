using Microsoft.AspNetCore.Identity;

namespace GitSearch.DbServices.Models.Database
{
    public class ApplicationUserClaim : IdentityUserClaim<Guid>
    {
        public virtual ApplicationUser? User { get; set; }
    }
}
