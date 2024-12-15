using InstaChef.DTO;
using InstaChef.Services;
using Microsoft.AspNetCore.Mvc;

namespace InstaChef.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class AuthController : ControllerBase    // login - sign up class ni sha
    {
        private readonly IAccountServices _accountServices;
        public AuthController(IAccountServices accountServices)
        {
            _accountServices = accountServices;
        }

        [HttpPost("signup")]
        public IActionResult CreateAccount(SignUp newAccount)
        {
            //string result = _accountServices.CreateAccount(newAccount);
            int? user = _accountServices.CreateAccount(newAccount);
            if (user == -1)
                return Conflict("User already exists.");
            
            if (user == null)
                return BadRequest("Failed to create an account");
            //var token = _jwtService.GenerateToken(user);    //later nani, kapoy setup ani

            return Ok(new {message = "Account created successfully.", session = user}); 
            //return CreatedAtRoute("getAccountById", new { username = result }, result); //ha? mao ni ang problem! this cause error 500
            // asa man ning getAccountById oi TTOTT
            // the problem is it wont save to the database once mag create kog account
        }

        [HttpPost("login")]
        public IActionResult LoginAccount(Login account)
        {
            int? user = _accountServices.LoginAccount(account);
            if (user == null)
               //return NotFound("User does not exists.");
               //no content means successful sha pero di sha ka hatag og output or no response body to send back to the client
               return NoContent();   //User does not exist

            //var token = _jwtService.GenerateToken(user);    //later nani, kapoy setup ani
            
            return Ok(new { message = "Login successful.", session = user });
        }
    }
}
