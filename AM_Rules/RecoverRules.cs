using AM_Data;
using AM_Models;

namespace AM_Rules
{
    public class RecoverRules
    {
        private SISAccountDataService sisdata;
        public RecoverRules()
        { sisdata = new SISAccountDataService(new SQLData()); }

        public SISAccount FindAccountByEmail(string sisEmail, SISType type)
        {
            var Accounts = sisdata.GetAccounts();
            foreach (var account in Accounts)
            {
                if (account.EmailAddress == sisEmail && account.Type == type)
                { return account; }
            }
            return null;
        }

        public bool RecoverSISAccountByEmail(string sisEmail, string newPassword, string newPassword2, SISType type)
        {
            var Accounts = sisdata.GetAccounts();
            foreach (var account in Accounts)
            {
                if (account.EmailAddress == sisEmail && account.Type == type)
                {
                    if (newPassword == newPassword2)
                    {
                        account.Password = newPassword;
                        return true;
                    }
                }
            }
            return false;
        }

    }
}