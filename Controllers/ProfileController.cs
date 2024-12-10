using InstaChef.DTO;
using InstaChef.Services;
using Microsoft.AspNetCore.Mvc;

namespace InstaChef.Controllers
{
    [ApiController]
    [Route("profile/")]
    public class ProfileController : ControllerBase
    {
        private readonly IAccountServices _accountServices;
        public ProfileController(IAccountServices accountServices) 
        {
            _accountServices = accountServices;
        }

        [HttpPut("edit-profile")]
        public IActionResult EditProfile(string currentAccount, EditProfile account)
        {
            if (!_accountServices.AccountExist(currentAccount)) return NotFound();
            _accountServices.EditProfile(currentAccount, account);
            return Ok(new { message = "Profile successfully updated" });
        }

        [HttpDelete("deactivate-account")]  //soft delete ni sha
        public IActionResult DeactivateAccount(string currentAccount)
        {
            if (!_accountServices.AccountExist(currentAccount)) return NotFound();
            _accountServices.DeactivateAccount(currentAccount);
            return Ok(new { message = "Successfully deactivated your account" });
        }

        [HttpGet]
        public IActionResult GetProfile()
        {
            return Ok();
        }

        [HttpGet("saved-recipes")]
        public IActionResult SavedRecipes()
        {
            return Ok();
        }

        [HttpGet("my-recipes")]
        public IActionResult MyRecipes()
        {
            return Ok();
        }

    }
}
