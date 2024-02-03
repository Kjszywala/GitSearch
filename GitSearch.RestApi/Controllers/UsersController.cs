using GitSearch.DbServices.Models.Database;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GitSearch.BusinessLogic.Helpers;

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
        ///     Constructor for UsersController.
        /// </summary>
        /// <param name="userManager">The UserManager for ApplicationUser instances.</param>
        public UsersController(UserManager<ApplicationUser> userManager)
        {
            this.userManager = userManager;
        }

        /// <summary>
        ///     Get all users.
        /// </summary>
        /// <returns>A list of all users.</returns>
        [HttpGet]
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
        ///     Create a new user.
        /// </summary>
        /// <param name="user">The user information for creation.</param>
        /// <returns>The created user.</returns>
        [HttpPost]
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
    }
}
