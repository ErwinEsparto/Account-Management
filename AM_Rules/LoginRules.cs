using AM_Data;
using AM_Models;

namespace AM_Rules
{
    public class LoginRules
    {
        private SISAccountDataService sisdata;

        public LoginRules()
        { sisdata = new SISAccountDataService(); }

        public SISAccount Login(string username, string password, SISType type)
        {
            SISAccount account = FindAccount(username, password, type);
            return account;
        }
        private SISAccount FindAccount(string username, string password, SISType type)
        {
            List<SISAccount> accounts = GetSISAccountByType(type);

            foreach(var account in accounts)
            {
                if(account.SISAccountNumber == username && account.Password == password && account.Type == type)
                {
                    SISAccount foundAccount = account;
                    return foundAccount;
                }
            }
            return null;
        }
        private List<SISAccount> GetSISAccountByType(SISType type)
        {
            List<SISAccount> SISAccounts = sisdata.GetAccounts();
            List<SISAccount> AccountsByType = new List<SISAccount>();

            foreach (var account in SISAccounts)
            {
                if (account.Type == type)
                { AccountsByType.Add(account); }
            }
            return AccountsByType;
        }
    }
}