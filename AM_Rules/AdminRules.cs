using AM_Data;
using AM_Models;

namespace AM_Rules
{
    public class AdminRules
    {
        private SISAccountDataService sisdata;
        public AdminRules()
        { sisdata = new SISAccountDataService(new SQLData()); }

        public List<SISAccount> GetAccounts(SISType type)
        {
            List<SISAccount> accounts = sisdata.GetAccounts();
            List<SISAccount> accountType = new List<SISAccount>();

            foreach (SISAccount account in accounts)
            {
                if(account.Type == type)
                {
                    accountType.Add(account);
                }
            }
            return accountType;
        }
        public SISAccount SearchAccount(string accountnumber)
        {
            List<SISAccount> accounts = sisdata.GetAccounts();

            foreach (SISAccount account in accounts)
            {
                if (account.SISAccountNumber == accountnumber)
                {
                    if (account.Type == SISType.Student || account.Type == SISType.Faculty)
                    {
                        SISAccount foundAccount = account;
                        return foundAccount;
                    }
                    else
                    {
                        return null;
                    }
                }
            }
            return null;
        }
        public bool DeleteAccount(string accountnumber)
        {
            List<SISAccount> accounts = sisdata.GetAccounts();

            foreach (SISAccount account in accounts)
            {
                if (account.SISAccountNumber == accountnumber)
                {
                    if(account.Type == SISType.Student || account.Type == SISType.Faculty)
                    {
                        SISAccount foundAccount = account;
                        sisdata.DeleteAccount(foundAccount);
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            return false;
        }
    }
}