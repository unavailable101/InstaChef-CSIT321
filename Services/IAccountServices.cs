using InstaChef.DTO;

namespace InstaChef.Services
{
    public interface IAccountServices
    {
        public int? CreateAccount(SignUp account);
        //public AccountDTO? CreateAccount(SignUp account);
        public int? LoginAccount(Login account);
        //public AccountDTO? LoginAccount(Login account);
        public bool AccountExist(string username);
        public void EditProfile(string username, EditProfile account);
        public void DeactivateAccount(string currentAccount);

        //public List<AccountDTO> GetAccounts();
        //public AccountDTO? GetAccountById(int id);
        //public bool DeleteAccountById(int id);
    }
}
