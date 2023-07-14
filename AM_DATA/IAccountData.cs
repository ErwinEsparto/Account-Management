using AM_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM_Data
{
    internal interface IAccountData
    {
        List<SISAccount> GetAccounts();
        void SaveAccounts(SISAccount Accounts);
        void UpdateAccounts(SISAccount Account);
    }
}
