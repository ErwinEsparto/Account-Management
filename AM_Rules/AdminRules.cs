using AM_Data;

namespace AM_Rules
{
    public class AdminRules
    {
        public bool checkAdminAccount(string username, string password)
        {
            AdminData d = new AdminData();
            List<string> adminEmailList = d.getAdminEmail();
            int existingemail = adminEmailList.IndexOf(username);

            List<string> adminPassword = d.getAdminPassword();
            int existingpassword = adminPassword.IndexOf(password);

            if (existingemail == -1 || existingpassword == -1)
            {
                return false;
            }
            else
            {
                bool checkingindex = checkIndex(username, password);
                if (checkingindex == true)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        public bool checkIndex(string username, string password)
        {
            AdminData d = new AdminData();

            List<string> adminEmailList = d.getAdminEmail();
            int emailIndex = adminEmailList.FindIndex(a => a.Contains(username));

            List<string> adminPassword = d.getAdminPassword();
            int passwordIndex = adminPassword.FindIndex(b => b.Contains(password));

            if (emailIndex == passwordIndex)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}