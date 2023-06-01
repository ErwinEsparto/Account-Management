using AM_Models;

namespace AM_Data
{
    public class InMemoryProfileData
    {
        private List<ProfileAccount> ProfileAccounts = new List<ProfileAccount>();

        public InMemoryProfileData()
        { CreateProfileAccounts(); }

        public List<ProfileAccount> GetProfileAccounts()
        { return ProfileAccounts; }

        private void CreateProfileAccounts()
        {

            SISAccountDataService sisdata = new SISAccountDataService();

            ProfileAccount profile1 = new ProfileAccount
            {
                SISAccount = sisdata.GetSISAccountByNumber("2011-00066-BN-0"),
                Username = "indaleenq",
                DateJoined = DateTime.Now,
                DateModified = DateTime.Now,
                PhotoPath = string.Empty
            };

            ProfileAccount profile2 = new ProfileAccount
            {
                SISAccount = sisdata.GetSISAccountByNumber("2011-00077-BN-0"),
                Username = "indaleen",
                DateJoined = DateTime.Now,
                DateModified = DateTime.Now,
                PhotoPath = string.Empty
            };

            ProfileAccount profile3 = new ProfileAccount
            {
                SISAccount = sisdata.GetSISAccountByNumber("2011-00088-BN-0"),
                Username = "inquinsayas",
                DateJoined = DateTime.Now,
                DateModified = DateTime.Now,
                PhotoPath = string.Empty
            };

            ProfileAccounts.Add(profile1);
            ProfileAccounts.Add(profile2);
            ProfileAccounts.Add(profile3);
        }
    }
}
