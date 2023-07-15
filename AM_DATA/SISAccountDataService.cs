using AM_Models;

namespace AM_Data
{
    public class SISAccountDataService
    {
        //private static InMemorySISData sisdata = new InMemorySISData();
        //private List<SISAccount> Accounts = sisdata.GetList();
        private List<SISAccount> Accounts { get; set; }
        IAccountData _accountData;
        public SISAccountDataService() { }
        public SISAccountDataService(IAccountData accountData)
        {
            _accountData = accountData;
            Accounts = new List<SISAccount>();
            Accounts = accountData.GetAccount();
        }

        public void registerAccount(SISAccount account)
        {
            _accountData.UpdateAccounts(account);
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