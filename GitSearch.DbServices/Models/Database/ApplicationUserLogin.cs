using Microsoft.AspNetCore.Identity;

namespace GitSearch.DbServices.Models.Database
{
    public class ApplicationUserLogin : IdentityUserLogin<Guid>
    {
        public virtual ApplicationUser? User { get; set; }
    }
}
