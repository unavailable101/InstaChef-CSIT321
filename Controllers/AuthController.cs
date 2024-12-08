using InstaChef.DTO;
using InstaChef.Services;
using Microsoft.AspNetCore.Mvc;

namespace InstaChef.Controllers
{
    public class AuthController : ControllerBase    // login - sign up class ni sha
    {
        private readonly IAccountServices _accountServices;
        public AuthController(IAccountServices accountServices)
        {
            _accountServices = accountServices;
        }

        [HttpPost]
        [Route("signup")]
        public IActionResult CreateAccount(SignUp newAccount)
        {
            string result = _accountServices.CreateAccount(newAccount);
            if (result == null)
                return Conflict("User already exists.");

            return CreatedAtRoute("getAccountById", new { username = result }, result);
        }

        [HttpPost]
        [Route("login")]
        public IActionResult LoginAccount(Login account)
        {
            string result = _accountServices.LoginAccount(account);
            if (result == null)
               return NotFound("User does not exists.");
            return Ok(new { message = "Login successful.", username = account.Username });
        }
    }
}
