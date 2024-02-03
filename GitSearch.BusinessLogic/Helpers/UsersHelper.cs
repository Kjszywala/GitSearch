using GitSearch.DbServices.Models.Database;

namespace GitSearch.BusinessLogic.Helpers
{
    /// <summary>
    ///     Helper class for mapping properties between ApplicationUser DTOs and entities.
    /// </summary>
    public static class UsersHelper
    {
        /// <summary>
        ///     Maps properties from a ApplicationUser DTO to a new ApplicationUser entity.
        /// </summary>
        /// <param name="userDto">The ApplicationUser DTO to map properties from.</param>
        /// <returns>A new ApplicationUser entity with mapped properties.</returns>
        public static ApplicationUser MapUserDtoToEntity(this ApplicationUser userDto)
        {
            var user = new ApplicationUser()
            {
                UserName = userDto.UserName,
                Logins = userDto.Logins,
                Tokens = userDto.Tokens,
                Claims = userDto.Claims,
                AccessFailedCount = userDto.AccessFailedCount,
                AccountCreationDate = userDto.AccountCreationDate,
                AlternateEmail = userDto.AlternateEmail,
                AlternatePhone = userDto.AlternatePhone,
                ConcurrencyStamp = userDto.ConcurrencyStamp,
                CreatedBy = userDto.CreatedBy,
                CreationDate = userDto.CreationDate,
                DateOfBirth = userDto.DateOfBirth,
                Email = userDto.Email,
                EmailConfirmed = userDto.EmailConfirmed,
                FirstName = userDto.FirstName,
                Id = userDto.Id,
                IsActive = userDto.IsActive,
                LastLoginDate = userDto.LastLoginDate,
                LockoutEnabled = userDto.LockoutEnabled,
                LockoutEnd = userDto.LockoutEnd,
                ModificationDate = userDto.ModificationDate,
                ModifiedBy = userDto.ModifiedBy,
                NormalizedEmail = userDto.NormalizedEmail,
                NormalizedUserName = userDto.NormalizedUserName,
                Notes = userDto.Notes,
                PasswordHash = userDto.PasswordHash,
                PhoneNumber = userDto.PhoneNumber,
                PhoneNumberConfirmed = userDto.PhoneNumberConfirmed,
                ProfilePicture = userDto.ProfilePicture,
                Roles = userDto.Roles,
                SecondName = userDto.SecondName,
                SecurityStamp = userDto.SecurityStamp,
                Title = userDto.Title,
                TwoFactorEnabled = userDto.TwoFactorEnabled,
                UserAddressId = userDto.UserAddressId
            };

            if (userDto.UserAddress != null)
            {
                user.UserAddress = new UserAddress
                {
                    IsActive = userDto.UserAddress.IsActive,
                    Title = userDto.UserAddress.Title,
                    City = userDto.UserAddress.City,
                    Country = userDto.UserAddress.Country,
                    CreationDate = userDto.UserAddress.CreationDate,
                    Latitude = userDto.UserAddress.Latitude,
                    Logtitude = userDto.UserAddress.Logtitude,
                    Id = userDto.UserAddress.Id,
                    ModificationDate = userDto.UserAddress.ModificationDate,
                    PostalCode = userDto.UserAddress.PostalCode,
                    Notes = userDto.UserAddress.Notes,
                    State = userDto.UserAddress.State,
                    StreetAddress = userDto.UserAddress.StreetAddress
                };
            }

            return user;
        }
    }
}