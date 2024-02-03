using GitSearch.DbServices.Models.Database;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GitSearch.BusinessLogic.Helpers;
using GitSearch.DbServices.Models.SearchRequests;

namespace GitSearch.RestApi.Controllers
{
    /// <summary>
    ///     Controller for managing user-related operations.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        /// <summary>
        ///     User manager for managing ApplicationUser instances.
        /// </summary>
        private readonly UserManager<ApplicationUser> userManager;

        /// <summary>
        ///     Manages sign-in functionality for ApplicationUser instances.
        /// </summary>
        private readonly SignInManager<ApplicationUser> signInManager;

        /// <summary>
        ///     Constructor for UsersController.
        /// </summary>
        /// <param name="userManager">The UserManager for ApplicationUser instances.</param>
        public UsersController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        /// <summary>
        ///     Get all users.
        /// </summary>
        /// <returns>A list of all users.</returns>
        [HttpGet]
        [Route("/user")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var result = await userManager.Users
                    .ToListAsync();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        ///     Get user by ID.
        /// </summary>
        /// <param name="id">The ID of the user to retrieve.</param>
        /// <returns>The user with the specified ID.</returns>
        [HttpGet]
        [Route("/user/{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            try
            {
                var user = await userManager.FindByIdAsync(id.ToString());

                if (user != null)
                {
                    return Ok(user);
                }
                else
                {
                    return NotFound($"User with ID {id} not found");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        ///     Get user by email.
        /// </summary>
        /// <param name="email">The email of the user to retrieve.</param>
        /// <returns>The user with the specified email.</returns>
        [HttpGet]
        [Route("/user/email/{email}")]
        public async Task<IActionResult> GetUserByEmail(string email)
        {
            try
            {
                var user = await userManager.FindByEmailAsync(email);

                if (user != null)
                {
                    return Ok(user);
                }
                else
                {
                    return NotFound($"User with email {email} not found");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        ///     Create a new user.
        /// </summary>
        /// <param name="user">The user information for creation.</param>
        /// <returns>The created user.</returns>
        [HttpPost]
        [Route("/user/create")]
        public async Task<IActionResult> Create(ApplicationUser user)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var result = await userManager.CreateAsync(user, user.PasswordHash);

                    if (result.Succeeded)
                    {
                        return Ok(user);
                    }
                    else
                    {
                        return BadRequest(result);
                    }
                }

                return BadRequest("Model is not valid.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        ///     Update an existing user.
        /// </summary>
        /// <param name="user">The updated user information.</param>
        /// <returns>The updated user.</returns>
        [HttpPut]
        [Route("/user/update")]
        public async Task<IActionResult> Update(ApplicationUser user)
        {
            try
            {
                var existingUser = await userManager.FindByIdAsync(user.Id.ToString());

                if (existingUser == null)
                {
                    return NotFound($"User with ID {user.Id} not found");
                }

                existingUser.MapUserDtoToEntity(user);

                var result = await userManager.UpdateAsync(user);

                if (result.Succeeded)
                {
                    return Ok(existingUser);
                }
                else
                {
                    return BadRequest(result.Errors);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        ///     Delete a user by ID.
        /// </summary>
        /// <param name="id">The ID of the user to delete.</param>
        /// <returns>Result of the deletion operation.</returns>
        [HttpDelete]
        [Route("/user/delete/{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                var user = await userManager.FindByIdAsync(id.ToString());

                if (user == null)
                {
                    return NotFound($"User with ID {id} not found");
                }

                var result = await userManager.DeleteAsync(user);

                if (result.Succeeded)
                {
                    return Ok($"User with ID {id} deleted successfully");
                }
                else
                {
                    return BadRequest(result.Errors);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        ///     Change the password for a user identified by their unique ID.
        /// </summary>
        /// <param name="id">The ID of the user to change the password for.</param>
        /// <param name="newPassword">The new password to set for the user.</param>
        /// <returns>ActionResult indicating the result of the password change operation.</returns>
        [HttpPut]
        [Route("/user/changePassword/{id}")]
        public async Task<IActionResult> ChangePassword(Guid id, string newPassword)
        {
            try
            {
                var user = await userManager.FindByIdAsync(id.ToString());

                if (user == null)
                {
                    return NotFound($"User with ID {id} not found");
                }

                var token = await userManager.GeneratePasswordResetTokenAsync(user);
                var result = await userManager.ResetPasswordAsync(user, token, newPassword);

                if (result.Succeeded)
                {
                    return Ok($"Password for user with ID {id} changed successfully");
                }
                else
                {
                    return BadRequest(result.Errors);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        ///     Search for users based on specified search criteria.
        /// </summary>
        /// <param name="searchTerm">The search criteria for filtering users.</param>
        /// <returns>ActionResult containing the list of users matching the search criteria.</returns>
        [HttpPost]
        [Route("/user/search")]
        public async Task<IActionResult> SearchUsers(UserSearchRequest searchTerm)
        {
            try
            {
                var users = await userManager.Users
                    .Where(u =>
                        (searchTerm.Id == null || u.Id == searchTerm.Id) &&
                        (string.IsNullOrEmpty(searchTerm.Email) || u.Email.Contains(searchTerm.Email)) &&
                        (string.IsNullOrEmpty(searchTerm.UserName) || u.UserName.Contains(searchTerm.UserName)) &&
                        (!searchTerm.EmailConfirmed.HasValue || u.EmailConfirmed == searchTerm.EmailConfirmed.Value) &&
                        (!searchTerm.TwoFactorEnabled.HasValue || u.TwoFactorEnabled == searchTerm.TwoFactorEnabled.Value) &&
                        (string.IsNullOrEmpty(searchTerm.FirstName) || u.FirstName.Contains(searchTerm.FirstName)) &&
                        (string.IsNullOrEmpty(searchTerm.SecondName) || u.SecondName.Contains(searchTerm.SecondName)) &&
                        (string.IsNullOrEmpty(searchTerm.Role) || userManager.IsInRoleAsync(u, searchTerm.Role).Result) &&
                        (!searchTerm.IsActive.HasValue || u.IsActive == searchTerm.IsActive.Value))
                    .ToListAsync();

                return Ok(users);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        ///     Sends a password reset link to the provided email.
        /// </summary>
        /// <param name="email">User's email address.</param>
        /// <returns>Status indicating success or failure.</returns>
        [HttpPost]
        [Route("/user/forgotPassword")]
        public async Task<IActionResult> ForgotPassword(string email)
        {
            try
            {
                var user = await userManager.FindByEmailAsync(email);

                if (user == null)
                {
                    // User not found with the provided email
                    return NotFound($"User with email {email} not found");
                }

                // Implement logic to send a password reset link to the user's email
                // Include a token in the link for security
                // Example: EmailService.SendPasswordResetEmail(user, resetToken);

                return Ok("Password reset link sent successfully");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        ///     Sets up two-factor authentication for the current user.
        /// </summary>
        /// <returns>Status indicating success or failure.</returns>
        [HttpPost]
        [Route("/user/setupTwoFactor")]
        public async Task<IActionResult> SetupTwoFactorAuth()
        {
            try
            {
                // Implement logic to enable two-factor authentication for the current user
                // Example: TwoFactorAuthenticator.SetupForUser(currentUser);

                return Ok("Two-factor authentication set up successfully");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        ///     Verifies the two-factor authentication code provided by the user.
        /// </summary>
        /// <param name="code">Two-factor authentication code.</param>
        /// <returns>Status indicating success or failure.</returns>
        [HttpPost]
        [Route("/user/verifyTwoFactor")]
        public async Task<IActionResult> VerifyTwoFactorAuth(string code)
        {
            try
            {
                // Implement logic to verify the provided two-factor authentication code
                // Example: TwoFactorAuthenticator.VerifyCode(currentUser, code);

                return Ok("Two-factor authentication code verified successfully");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        ///     Logs out the current user.
        /// </summary>
        /// <returns>Status indicating success or failure.</returns>
        [HttpPost]
        [Route("/user/logout")]
        public async Task<IActionResult> Logout()
        {
            try
            {
                await signInManager.SignOutAsync();

                return Ok("User logged out successfully");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
