using InstaChef.Models;

namespace InstaChef
{
    public class TempDB
    {
        public static List<Account> tempAccountList = new List<Account>()
        {
            new Account
            {
                Id = 1,
                FirstName = "Niña Margarette",
                LastName = "Catubig",
                Username = "cuteko",
                Email = "marga18nins@gmail.com",
                Password = "testing"
            },
            new Account
            {
                Id = 2,
                FirstName = "Francis Benedict",
                LastName = "Chavez",
                Username = "benedict",
                Email = "francischavez@gmail.com",
                Password = "testing2"
            },
            new Account
            {
                Id = 3,
                FirstName = "Paul Thomas",
                LastName = "Abellana",
                Username = "thomas",
                Email = "paulabellana@gmail.com",
                Password = "testing3"
            },
            new Account
            {
                Id = 4,
                FirstName = "Moriel",
                LastName = "Bien",
                Username = "bien",
                Email = "morielbien@gmail.com",
                Password = "testing4"
            }
        };
    }
}
