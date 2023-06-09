﻿using AM_Data;
using AM_Models;

namespace AM_Rules
{
    public class RegisterRules
    {
        SISAccountDataService sisdata = new SISAccountDataService();

        public void CreateAccount(string username, string email, string password, SISType accountType)
        {
            SISAccount account = new SISAccount()
            {
                SISAccountNumber = username,
                EmailAddress = email,
                Password = password,
                Type = accountType,
                DateCreated = DateTime.Now,
                DateModified = DateTime.Now
            };
            sisdata.AddAccount(account);
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