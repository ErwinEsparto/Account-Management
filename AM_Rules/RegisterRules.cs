using AM_Data;
using AM_Models;

namespace AM_Rules
{
    public class RegisterRules
    {
        public SISAccountDataService sisdata;
        public RegisterRules()
        { sisdata = new SISAccountDataService(new SQLData()); }

        public bool CreateAccount(string username, string email, string password, SISType accountType)
        {
            List<SISAccount> accounts = sisdata.GetAccounts();
            foreach (SISAccount account in accounts) 
            {
                if(account.SISAccountNumber == username || account.EmailAddress == email)
                {
                    return false;
                }
            }
            SISAccount NewAccount = new SISAccount()
            {
                SISAccountNumber = username,
                EmailAddress = email,
                Password = password,
                Type = accountType,
                DateCreated = DateTime.Now,
                DateModified = DateTime.Now
            };
            sisdata.registerAccount(NewAccount);
            return true;
        }
        public bool CheckFormat(string username, SISType type)
        {
            if (username.Length == 15 && type == SISType.Student)
            { return true; }
            else if (username.Length == 12 && type == SISType.Faculty)
            { return true; }
            else { return false; }
        }
    }
}