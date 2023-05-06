namespace AM_Data
{
    public class AdminData
    {
        private List <string> adminEmail = new List<string> (4)
        {"Jaspher.Baet@gmail.com","espartoerwin@gmail.com","Kenneth.Odgien@gmail.com","Lilac.Goodrich@gmail.com"};
        private List<string> adminPassword = new List<string>(4)
        {"baet123","erwin456","odgien789","lilac01"};

        public List<string> getAdminEmail()
        {
            return adminEmail;
        }
        public List<string> getAdminPassword()
        {
            return adminPassword;
        }
    }
}