using InstaChef.DTO;

namespace InstaChef.Services
{
    public interface IAccountServices
    {
        public string CreateAccount(SignUp account);
        //public AccountDTO? CreateAccount(SignUp account);
        public string LoginAccount(Login account);
        //public AccountDTO? LoginAccount(Login account);
        public bool AccountExist(string username);
        public void EditProfile(string username, EditAccount account);
        public void DeactivateAccount(string currentAccount);

        //public List<AccountDTO> GetAccounts();
        //public AccountDTO? GetAccountById(int id);
        //public bool DeleteAccountById(int id);
    }
}
