using AM_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM_Data
{
    public interface IAccountData
    {
        List<SISAccount> GetAccount();
        void SaveAccounts(SISAccount Accounts);
        void UpdateAccounts(SISAccount Account);
        void DeleteAccount(SISAccount Account);
    }
}
