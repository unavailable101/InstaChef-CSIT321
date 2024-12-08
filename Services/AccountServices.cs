using InstaChef.DTO;
using InstaChef.Models;
using InstaChef.Repository;

namespace InstaChef.Services
{
    public class AccountServices : IAccountServices
    {
        //private readonly IAccountRepository _accountRepository;
        private readonly IDataRepository _dataRepository;

        public AccountServices(IDataRepository dataRepository)
        {
            _dataRepository = dataRepository;
        }

        public void DeactivateAccount(string currentAccount)
        {
            _dataRepository.ChangeStatus(currentAccount);
        }

        public bool AccountExist(string username)
        {
            return _dataRepository.GetAccountByUsername(username) != null ? true : false;
        }
        public void EditProfile(string username, EditProfile account)
        {
            _dataRepository.UpdateAccount(
                    username, 
                    account.FirstName, 
                    account.LastName, 
                    account.Email, 
                    HashPassword(account.Password)
                );
        }

        public string LoginAccount(Login account)
        {
            var currAccount = _dataRepository.GetAccountByUsername(account.Username);
            if (currAccount == null || currAccount.Status == 0) return null;
            if ( !VerifyPassword(account.Password, currAccount.Password) ) return null;
            return currAccount.Username;
        }

        //public AccountDTO? CreateAccount(SignUp account) 
        public string CreateAccount(SignUp account) 
        {
            // unique username and email address
            if (
                _dataRepository.GetAccountByUsername(account.Username) != null ||
                _dataRepository.GetAccountByEmail(account.Email) != null)
                return null;

            //might use later, for hashing of passwords
            string hashedPassword = HashPassword(account.Password);

            //var newAccount = new AccountDTO()
            //{
            //    FirstName = account.FirstName,
            //    LastName = account.LastName,
            //    Username = account.Username,
            //    Email = account.Email,
            //    Password = hashedPassword,
            //    Status = 1
            //};

            _dataRepository.AddAccount(
                    //account.FirstName,
                    //account.LastName,
                    account.Username,
                    account.Email,
                    hashedPassword,
                    1
                );

            return account.Username;
        }

        //later nani kay wa pa nako na add ang BCrypt
        private string HashPassword(string password)
        {
            //return BCrypt.Net.BCrypt.HashPassword(password);
            return "testing";
        }

        private bool VerifyPassword(string rawPassword, string HashedPassword) 
        {
            //return BCrypt.Net.BCrypt.Verify(plainPassword, hashedPassword);
            return rawPassword == HashedPassword;
        }


        //do not uncomment below!

        //public AccountDTO? GetAccountById(int id)
        //{
        //    var account = _accountRepository.GetAccountById(id);
        //    if (account == null) return null;
        //    return new AccountDTO()
        //    {
        //        FirstName = account.FirstName, 
        //        LastName = account.LastName,
        //        Username = account.Username,
        //        Email = account.Email,
        //        Password = account.Password
        //    };
        //    throw new NotImplementedException();

        //}

        //public List<AccountDTO> GetAccounts()
        //{
        //    var accounts = _accountRepository.GetAccounts();
        //    return accounts.Select(account => new AccountDTO
        //    {
        //        FirstName = account.FirstName,
        //        LastName = account.LastName,
        //        Username= account.Username,
        //        Email = account.Email,
        //        Password = account.Password
        //    }).ToList();
        //    throw new NotImplementedException();
        //}

        //public bool DeleteAccountById(int id) {
        //    return _accountRepository.DeleteAccountById(id);
        //}
    }
}
