using AM_Data;
using AM_Models;

namespace AM_Rules
{
    public class LoginRules
    {
        SISAccountDataService sisdata = new SISAccountDataService();

        public SISAccount Login(string username, string password, SISType type)
        {
            SISAccount account = CheckAccount(username, password, type);
            return account;
        }
        private SISAccount CheckAccount(string username, string password, SISType type)
        {
            List<SISAccount> accounts = GetSISAccountByType(type);
            SISAccount foundAccount = new SISAccount();

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
        private List<SISAccount> GetSISAccountByType(SISType type)
        {
            List<SISAccount> allaccounts = sisdata.GetAccounts();
            List<SISAccount> accountsByType = new List<SISAccount>();

            foreach (var account in allaccounts)
            {
                if (account.Type == type)
                { accountsByType.Add(account); }
            }
            return accountsByType;
        }
    }
}