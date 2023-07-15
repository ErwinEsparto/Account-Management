using AM_Models;

namespace AM_Data
{
    public class SISAccountDataService
    {
        
        private List<SISAccount> Accounts { get; set; }
        private static InMemorySISData sisdata;
        IAccountData _accountData;

        public SISAccountDataService()
        {
            sisdata = new InMemorySISData();
            Accounts = sisdata.GetList();
        }
        public SISAccountDataService(IAccountData accountData)
        {
            _accountData = accountData;
            Accounts = new List<SISAccount>();
            Accounts = accountData.GetAccount();
        }

        public void registerAccount(SISAccount account)
        {
            _accountData.SaveAccounts(account);
        }


        public List<SISAccount> GetAccounts()
        { return Accounts; }

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