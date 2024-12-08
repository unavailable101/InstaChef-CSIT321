using InstaChef.DTO;
using InstaChef.Services;
using Microsoft.AspNetCore.Mvc;

namespace InstaChef.Controllers
{
    public class ProfileController : ControllerBase
    {
        private readonly IAccountServices _accountServices;
        public ProfileController(IAccountServices accountServices) 
        {
            _accountServices = accountServices;
        }

        [HttpPut]
        [Route("edit-profile")]
        public IActionResult EditProfile(string currentAccount, EditProfile account)
        {
            if (!_accountServices.AccountExist(currentAccount)) return NotFound();
            _accountServices.EditProfile(currentAccount, account);
            return Ok(new { message = "Profile successfully updated" });
        }

        [HttpPut]
        [Route("deactivate-account")]
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

        [HttpGet]
        public IActionResult SavedRecipes() 
        {
            return Ok();
        }

        [HttpGet]
        public IActionResult MyRecipes() 
        {
            return Ok();
        }
        
    }
}
