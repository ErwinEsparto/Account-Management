using AM_Data;
using AM_Models;

namespace AM_Rules
{
    public class RecoverRules
    {
        SISAccountDataService sisdata = new SISAccountDataService();
        
        public bool RecoverSISAccountByEmail(string sisEmail, string newPassword, string newPassword2)
        {
            var Accounts = sisdata.GetAccounts();
            foreach (var account in Accounts)
            {
                if (account.EmailAddress == sisEmail)
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
        public SISAccount FindAccountByEmail(string sisEmail)
        {
            var Accounts = sisdata.GetAccounts();
            foreach (var account in Accounts)
            {
                if (account.EmailAddress == sisEmail)
                { return account; }
            }
            return null;
        }
    }
}