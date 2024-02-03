using GitSearch.DbServices.Models.Database;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GitSearch.BusinessLogic.Helpers;

namespace GitSearch.RestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> userManager;

        public UsersController(UserManager<ApplicationUser> userManager)
        {
            this.userManager = userManager;
        }

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
