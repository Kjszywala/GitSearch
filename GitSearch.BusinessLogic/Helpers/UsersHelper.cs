using GitSearch.DbServices.Models.Database;

namespace GitSearch.BusinessLogic.Helpers
{
    /// <summary>
    ///     Helper class for mapping properties between ApplicationUser DTOs and entities.
    /// </summary>
    public static class UsersHelper
    {
        /// <summary>
        /// Maps properties from a ApplicationUser DTO to an existing ApplicationUser entity.
        /// </summary>
        /// <param name="entity">The existing ApplicationUser entity to be updated.</param>
        /// <param name="userDto">The ApplicationUser DTO containing updated values.</param>
        public static void MapUserDtoToEntity(this ApplicationUser entity, ApplicationUser userDto)
        {
            entity.UserName = userDto.UserName;
            entity.Logins = userDto.Logins;
            entity.Tokens = userDto.Tokens;
            entity.Claims = userDto.Claims;
            entity.AccessFailedCount = userDto.AccessFailedCount;
            entity.AccountCreationDate = userDto.AccountCreationDate;
            entity.AlternateEmail = userDto.AlternateEmail;
            entity.AlternatePhone = userDto.AlternatePhone;
            entity.ConcurrencyStamp = userDto.ConcurrencyStamp;
            entity.CreatedBy = userDto.CreatedBy;
            entity.CreationDate = userDto.CreationDate;
            entity.DateOfBirth = userDto.DateOfBirth;
            entity.Email = userDto.Email;
            entity.EmailConfirmed = userDto.EmailConfirmed;
            entity.FirstName = userDto.FirstName;
            entity.Id = userDto.Id;
            entity.IsActive = userDto.IsActive;
            entity.LastLoginDate = userDto.LastLoginDate;
            entity.LockoutEnabled = userDto.LockoutEnabled;
            entity.LockoutEnd = userDto.LockoutEnd;
            entity.ModificationDate = userDto.ModificationDate;
            entity.ModifiedBy = userDto.ModifiedBy;
            entity.NormalizedEmail = userDto.NormalizedEmail;
            entity.NormalizedUserName = userDto.NormalizedUserName;
            entity.Notes = userDto.Notes;
            entity.PasswordHash = userDto.PasswordHash;
            entity.PhoneNumber = userDto.PhoneNumber;
            entity.PhoneNumberConfirmed = userDto.PhoneNumberConfirmed;
            entity.ProfilePicture = userDto.ProfilePicture;
            entity.Roles = userDto.Roles;
            entity.SecondName = userDto.SecondName;
            entity.SecurityStamp = userDto.SecurityStamp;
            entity.Title = userDto.Title;
            entity.TwoFactorEnabled = userDto.TwoFactorEnabled;

            if (userDto.UserAddress != null)
            {
                entity.UserAddressId = userDto.UserAddressId;
                entity.UserAddress = userDto.UserAddress;
            }
        }
    }
}