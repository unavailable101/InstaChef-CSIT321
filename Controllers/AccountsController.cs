using InstaChef.Models;
using InstaChef.DTO;
using Microsoft.AspNetCore.Mvc;
using InstaChef.Services;
using System.Security.Principal;

namespace InstaChef.Controllers
{
    [ApiController]
    [Route("/api")]
    //[Route("/api/accounts")]
    public class AccountsController : ControllerBase
    {
        private readonly IAccountServices _accountServices;

        public AccountsController(IAccountServices accountServices)
        {
            _accountServices = accountServices;
        }


        [HttpPost]
        [Route("signup")]
        public IActionResult CreateAccount (SignUp newAccount)
        {
            //var result = _accountServices.CreateAccount(newAccount);
            string result = _accountServices.CreateAccount(newAccount);
            if (result == null)
                return Conflict("User already exists.");

            //return CreatedAtRoute("getAccountById", new { id = result.Id }, result);
            // by username nlng ni, kapoy
            return CreatedAtRoute("getAccountById", new { username = result}, result);
        }
        
        [HttpPost]
        [Route("login")]
        public IActionResult LoginAccount (Login account)
        {
            //var result = _accountServices.LoginAccount(account);
            //if (result == null)
            string result = _accountServices.LoginAccount(account);
            if (result == null)
                //return Unauthorized("User does not exists.");
                return NotFound("User does not exists.");
            // by username nlng ni, kapoy
            return Ok(new { message = "Login successful.", username = account.Username });
        }

        [HttpPut]
        [Route("edit-profile")]
        public IActionResult EditProfile(string currentAccount, EditAccount account) 
        {
            if ( !_accountServices.AccountExist(currentAccount) ) return NotFound();
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


        //everything below kay base sa video ni sir
        //do not uncomment!

        //[HttpGet]
        //public IActionResult getAccounts()
        //{
        //    //if (TempDB.tempAccountList.Count == 0) return BadRequest("No accounts has been stored yet.");
        //    //return Ok();
        //    var accounts = _accountServices.GetAccounts();
        //    if (accounts == null) return NotFound("No accounts has been stored yet.");
        //    return Ok(accounts);

        //}

        //[HttpGet]
        //[Route("{id}", Name = "getAccountById")]
        //public IActionResult getAccountById(int id)
        //{
        //    //var account = TempDB.tempAccountList.SingleOrDefault(x => x.Id == id);
        //    //if (account == null) return NotFound($"Account does not exist. id:{id}");
        //    //return Ok(account);
        //    var account = _accountServices.GetAccountById(id);
        //    if (account == null) return NotFound("Account does not exist");
        //    return Ok(account);
        //}

        //[HttpDelete]
        //[Route("{id}")]
        //public IActionResult deleteAccountById(int id)
        //{
        //    //var account = TempDB.tempAccountList.SingleOrDefault(x => x.Id == id);
        //    //if (account == null) return NotFound($"Account does not exist. id:{id}");
        //    //TempDB.tempAccountList.Remove(account);
        //    //return NoContent();
        //    var account = _accountServices.DeleteAccountById(id);
        //    if (!account) return NotFound($"Account does not exist. id:{id}");
        //    return NoContent();
        //}

        //[HttpPost]
        //public IActionResult CreateAccount(AccountDTO account)
        //{
        //    //if ((_tempAccountList.SingleOrDefault(x => x.Id == account.Id)) != null)
        //    //    return Conflict("Account already exist");
        //    //_tempAccountList.Add(account);
        //    //return Ok("Account created successfully");
        //    int id = TempDB.tempAccountList.Max(x => x.Id) + 1;
        //    Account newAccount = new Account()
        //    {
        //        Id = id,
        //        FirstName = account.FirstName,
        //        LastName = account.LastName,
        //        Username = account.Username,
        //        Email = account.Email,
        //        Password = account.Password
        //    };
        //    TempDB.tempAccountList.Add(newAccount);
        //    return CreatedAtRoute("getAccountById", new { id = id }, newAccount);

        //}
        
        //[HttpPut]
        //public IActionResult UpdateAccount(int id, AccountDTO account)
        //{
        //    var existingAccount = TempDB.tempAccountList.SingleOrDefault(x => x.Id == id);
        //    if (existingAccount == null)
        //        return NotFound("Account does not exist.");
            
        //    existingAccount.FirstName = account.FirstName;
        //    existingAccount.LastName = account.LastName;
        //    existingAccount.Username = account.Username;
        //    existingAccount.Email = account.Email;
        //    existingAccount.Password = account.Password;
        //    return Ok(existingAccount);
            
        //}
    }
}
