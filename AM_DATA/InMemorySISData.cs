using AM_Models;

namespace AM_Data
{
    public class InMemorySISData
    {
        private List<SISAccount> SISAccounts = new List<SISAccount>();

        public InMemorySISData()
        { CreateAccounts(); }

        public List<SISAccount> GetList()
        { return SISAccounts; }

        private void CreateAccounts()
        {
            SISAccount admin1 = new SISAccount
            {
                SISAccountNumber = "erwin",
                EmailAddress = "espartoerwin@gmail.com",
                Password = "erwin123",
                Type = SISType.Admin,
                DateCreated = DateTime.Now,
                DateModified = DateTime.Now
            };
            SISAccount admin2 = new SISAccount
            {
                SISAccountNumber = "jaspher",
                EmailAddress = "baetjaspher@gmail.com",
                Password = "jaspher456",
                Type = SISType.Admin,
                DateCreated = DateTime.Now,
                DateModified = DateTime.Now
            };
            SISAccount admin3 = new SISAccount
            {
                SISAccountNumber = "kenneth",
                EmailAddress = "odgienkenneth@gmail.com",
                Password = "kenneth789",
                Type = SISType.Admin,
                DateCreated = DateTime.Now,
                DateModified = DateTime.Now
            };
            SISAccount admin4 = new SISAccount
            {
                SISAccountNumber = "lilac",
                EmailAddress = "lilacgoodrich@gmail.com",
                Password = "lilac456",
                Type = SISType.Admin,
                DateCreated = DateTime.Now,
                DateModified = DateTime.Now
            };

            SISAccount student1 = new SISAccount
            {
                SISAccountNumber = "2020-12345-BN-0",
                EmailAddress = "student@gmail.com",
                Password = "studentpass",
                Type = SISType.Student,
                DateCreated = DateTime.Now,
                DateModified = DateTime.Now
            };

            SISAccount faculty1 = new SISAccount
            {
                SISAccountNumber = "FA0002BN2016",
                EmailAddress = "faculty@gmail.com",
                Password = "facultypass",
                Type = SISType.Faculty,
                DateCreated = DateTime.Now,
                DateModified = DateTime.Now
            };
            SISAccounts.Add(admin1);
            SISAccounts.Add(admin2);
            SISAccounts.Add(admin3);
            SISAccounts.Add(admin4);
            SISAccounts.Add(student1);
            SISAccounts.Add(faculty1);
        }
    }
}