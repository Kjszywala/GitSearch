using Microsoft.AspNetCore.Identity;

namespace GitSearch.DbServices.Models.Database;

public class ApplicationUser : IdentityUser<Guid>
{
    /// <summary>
    ///     FirstName
    /// </summary>
    public string FirstName { get; set; }

    /// <summary>
    ///     SecondName
    /// </summary>
    public string SecondName { get; set; }

    /// <summary>
    ///     AlternateEmail
    /// </summary>
    public string? AlternateEmail { get; set; }

    /// <summary>
    ///     AlternatePhone
    /// </summary>
    public string? AlternatePhone { get; set; }

    /// <summary>
    ///     CreatedBy
    /// </summary>
    public string? CreatedBy { get; set; }

    /// <summary>
    ///     ModifiedBy
    /// </summary>
    public string? ModifiedBy { get; set; }

    /// <summary>
    ///     BirthDate
    /// </summary>
    public DateTime? DateOfBirth { get; set; }

    /// <summary>
    ///     LastLoginDate
    /// </summary>
    public DateTimeOffset? LastLoginDate { get; set; }

    /// <summary>
    ///     AccountCreationDate
    /// </summary>
    public DateTimeOffset? AccountCreationDate { get; set; }

    /// <summary>
    ///     CreationDate
    /// </summary>
    public DateTime CreationDate { get; set; }

    /// <summary>
    ///     ModificationDate
    /// </summary>
    public DateTime ModificationDate { get; set; }

    /// <summary>
    ///     IsActive
    /// </summary>
    public bool IsActive { get; set; }

    /// <summary>
    ///     Notes
    /// </summary>
    public string? Notes { get; set; }

    /// <summary>
    ///     Title
    /// </summary>
    public string? Title { get; set; }

    /// <summary>
    ///     ProfilePicturel
    /// </summary>
    public byte[]? ProfilePicture { get; set; }

    /// <summary>
    ///     UserAddressId
    /// </summary>
    public Guid? UserAddressId { get; set; }

    /// <summary>
    ///     UserAddress
    /// </summary>
    public UserAddress? UserAddress { get; set; }

    /// <summary>
    ///     Claims
    /// </summary>
    public virtual ICollection<ApplicationUserClaim>? Claims { get; set; }

    /// <summary>
    ///     Logins
    /// </summary>
    public virtual ICollection<ApplicationUserLogin>? Logins { get; set; }

    /// <summary>
    ///     Roles
    /// </summary>
    public virtual ICollection<ApplicationUserRole>? Roles { get; set; }

    /// <summary>
    ///     Tokens
    /// </summary>
    public virtual ICollection<ApplicationUserToken>? Tokens { get; set; }

}