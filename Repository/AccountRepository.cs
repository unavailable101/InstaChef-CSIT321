using InstaChef.Models;

namespace InstaChef.Repository
{
    public class AccountRepository : IAccountRepository
    {
        // !!! I'll not use this class !!!

        private readonly InstaChefDbContext _context;   
        public AccountRepository(InstaChefDbContext context)
        {
            _context = context;
        }
        public void ChangeStatus(string currentAccount)
        {
            var existingAccount = _context.Account.SingleOrDefault(x => x.Username == currentAccount);
            if (existingAccount.Status == 1) existingAccount.Status = 0;
            else existingAccount.Status = 1;
        }
        public void UpdateAccount(string username, string FirstName, string LastName, string Email, string hashPass)
        {
            var existingAccount = _context.Account.SingleOrDefault(x => x.Username == username);

            if (FirstName != null) existingAccount.FirstName = FirstName;
            if (LastName != null) existingAccount.LastName = LastName;
            if (Email != null) existingAccount.Email = Email;
            if (hashPass != null) existingAccount.Password = hashPass;
        }

        //public void AddAccount(string firstName, string lastName, string username, string email, string password, int status)
        public void AddAccount(string username, string email, string password, int status)
        {
            int id = _context.Account.Max(x => x.Id) + 1;
            Account newAccount = new Account()
            {
                Id = id,
                //FirstName = firstName,
                //LastName = lastName,
                Username = username,
                Email = email,
                Password = password,
                Status = 1
            };
            TempDB.tempAccountList.Add(newAccount);
        }
        
        public Account? GetAccountByEmail(string email)
        {
            return _context.Account.SingleOrDefault(x => x.Email == email);
        }

        public Account? GetAccountByUsername(string username)
        {
            return _context.Account.SingleOrDefault(x => x.Username == username);
        }




        //do not uncomment!

        //public Account? GetAccountById(int id)
        //{
        //    return TempDB.tempAccountList.SingleOrDefault(x => x.Id == id);
        //    throw new NotImplementedException();

        //}

        //public List<Account> GetAccounts()
        //{
        //    return TempDB.tempAccountList;
        //    throw new NotImplementedException();
        //}

        //public bool DeleteAccountById(int id) {
        //    var account = TempDB.tempAccountList.SingleOrDefault(x => x.Id == id);
        //    if (account == null) return false;
        //    TempDB.tempAccountList.Remove(account);
        //    return true;
        //}
    }
}
