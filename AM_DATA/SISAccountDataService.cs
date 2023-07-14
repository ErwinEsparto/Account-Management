using AM_Models;

namespace AM_Data
{
    public class SISAccountDataService
    {
        private static InMemorySISData sisdata = new InMemorySISData();
        private List<SISAccount> Accounts = sisdata.GetList();
        
        public List<SISAccount> GetAccounts()
        {
            return Accounts;
        }

        public void AddAccount(SISAccount newAccount)
        { Accounts.Add(newAccount); }

        public SISAccount GetSISAccountByNumber(string sisNumber)
        {
            foreach (var account in Accounts)
            {
                if (account.SISAccountNumber == sisNumber)
                { return account; }
            }
            return new SISAccount();
        }
    }
}