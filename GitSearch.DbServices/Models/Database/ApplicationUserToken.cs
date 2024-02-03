using Microsoft.AspNetCore.Identity;

namespace GitSearch.DbServices.Models.Database
{
    public class ApplicationUserToken : IdentityUserToken<Guid>
    {
        public virtual ApplicationUser? User { get; set; }
    }
}
