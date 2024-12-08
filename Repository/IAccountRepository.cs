using InstaChef.Models;
using System.Runtime.CompilerServices;
using System.Security.Principal;

namespace InstaChef.Repository
{
    public interface IAccountRepository
    {
        // !!! I'll not use this class !!!

        //public void AddAccount(string firstName, string lastName, string username, string email, string password, int status);
        public void AddAccount(string username, string email, string password, int status);
        public Account? GetAccountByEmail(string  email);
        public Account? GetAccountByUsername(string  username);
        public void UpdateAccount(string username, string FirstName, string LastName, string Email, string hashPass);
        public void ChangeStatus(string currentAccount);
        //public List<Account> GetAccounts();
        //public Account? GetAccountById(int id);
        //bool DeleteAccountById(int id);
    }
}
