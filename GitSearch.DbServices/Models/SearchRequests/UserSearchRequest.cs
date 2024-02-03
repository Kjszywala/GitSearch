namespace GitSearch.DbServices.Models.SearchRequests
{
    /// <summary>
    ///     Find users with search criteria.
    /// </summary>
    public class UserSearchRequest : BaseSearchRequest
    {
        /// <summary>
        ///     Email
        /// </summary>
        public string? Email { get; set; }

        /// <summary>
        ///     UserName
        /// </summary>
        public string? UserName { get; set; }

        /// <summary>
        ///     EmailConfirmed
        /// </summary>
        public bool? EmailConfirmed { get; set; }

        /// <summary>
        ///     TwoFactorEnabled
        /// </summary>
        public bool? TwoFactorEnabled { get; set; }

        /// <summary>
        ///     FirstName
        /// </summary>
        public string? FirstName { get; set; }

        /// <summary>
        ///     SecondName
        /// </summary>
        public string? SecondName { get; set; }

        /// <summary>
        ///     Role
        /// </summary>
        public string? Role { get; set; }

        /// <summary>
        ///     IsActive
        /// </summary>
        public bool? IsActive { get; set; }
    }
}
