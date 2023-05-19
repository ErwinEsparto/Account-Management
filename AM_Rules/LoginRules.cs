using AM_Data;
using AM_Models;

namespace AM_Rules
{
    public class LoginRules
    {
        public SISAccount? Login(string username, string password, SISType type)
        {
            SISAccount? account = checkAccount(username, password, type);
            return account;
        }
        private SISAccount? checkAccount(string username, string password, SISType type)
        {
            List<SISAccount> accounts = getSISAccountByType(type);
            SISAccount? foundAccount = new SISAccount();

            var findaccount = (from account in accounts
                               where
                               account.SISAccountNumber.Equals(username) &&
                               account.Password.Equals(password) &&
                               account.Type.Equals(type)
                               select account).FirstOrDefault();

            if (findaccount != null)
            {
                foundAccount = findaccount;
                return foundAccount;
            }
            else { return null; }
        }
        public bool checkFormat(string username, SISType type)
        {
            if (username.Length == 15 && type == SISType.Student)
            { return true; }
            else if (username.Length == 12 && type == SISType.Faculty)
            { return true; }
            else { return false; }
        }

        public void createAccount(string username, string email, string password, SISType type)
        {
            InMemorySISData data = new InMemorySISData();
            SISAccount account = new SISAccount
            {
                SISAccountNumber = username,
                EmailAddress = email,
                Password = password,
                Type = type,
                DateCreated = DateTime.Now,
                DateModified = DateTime.Now
            };
            data.AddAccount(account);
        }
        private List<SISAccount> getSISAccountByType(SISType type)
        {
            InMemorySISData accountdata = new InMemorySISData();
            var accounts = accountdata.getList();

            List<SISAccount> accountsByTpe = new List<SISAccount>();

            foreach (var account in accounts)
            {
                if (account.Type == type)
                { accountsByTpe.Add(account); }
            }
            return accountsByTpe;
        }
    }
}