using Microsoft.AspNetCore.Identity;

namespace GitSearch.DbServices.Models.Database
{
    public class ApplicationRole : IdentityRole<Guid>
    {
        /// <summary>
        ///     UserRoles
        /// </summary>
        public virtual ICollection<ApplicationUserRole>? UserRoles { get; set; }

        /// <summary>
        ///     UserClaims
        /// </summary>
        public virtual ICollection<ApplicationRoleClaim>? RoleClaims { get; set; }
    }
}
