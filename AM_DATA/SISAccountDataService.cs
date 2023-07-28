using AM_Models;

namespace AM_Data
{
    public class SISAccountDataService
    {
        
        private List<SISAccount> Accounts { get; set; }
        IAccountData _accountData;

        public SISAccountDataService(IAccountData accountData)
        {
            _accountData = accountData;
            Accounts = new List<SISAccount>();
            Accounts = accountData.GetAccount();
        }

        public void registerAccount(SISAccount RAsisAccount)
        {
            _accountData.SaveAccounts(RAsisAccount);
        }

        public void DeleteAccount(SISAccount account)
        {
            _accountData.DeleteAccount(account);
        }

        public List<SISAccount> GetAccounts()
        { return Accounts; }


        public SISAccount GetSISAccountByNumber(string sisNumber)
        {
            foreach (var account in Accounts)
            {
                if (account.SISAccountNumber == sisNumber)
                { return account; }
            }
            return new SISAccount();
        }
        public void updateAccount(SISAccount UAsisAccount)
        {
            _accountData.UpdateAccounts(UAsisAccount);
        }
    }
}