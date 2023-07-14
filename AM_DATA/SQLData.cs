//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Data.SqlClient;
//using Microsoft.Data.SqlClient;
//using AM_Models;

//namespace AM_Data
//{
//    public class SQLData : IAccountData
//    {
//            static string connectionString = "Server=localhost;Database=Account;Trusted_Connection=True;";

//            static SqlConnection sqlConnection;

//        public SISAccountDataService sisAccountDataService = new SISAccountDataService();

//        SQLData() { sqlConnection = new SqlConnection(connectionString); }

//        public List<SISAccount> GetAccounts() 
//        {
//            String selectStatement = "SELECT SISAccount, SISPassword FROM Account";

//            SqlCommand selectCommand = new SqlCommand(selectStatement, sqlConnection);
//            sqlConnection.Open();
//            SqlDataReader reader = selectCommand.ExecuteReader();

//            var SISAccounts = new List<SISAccount>();

//            while (reader.Read())
//            {
//                SISAccounts.Add(new SISAccount
//                {
//                    EmailAddress = sisAccountDataService.GetSISAccountByNumber(reader["SISAccount"].ToString()),
//                    Password = reader["SISPassword"].ToString()
//                });
//            }

//            sqlConnection.Close();
//            return SISAccounts;
//           ; 
//        }
//        public void SaveAccounts(List<SISAccount> Accounts) { }
//        public void UpdateAccounts(SISAccount Account) { }
//    }
//}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Microsoft.Data.SqlClient;
using AM_Models;

namespace AM_Data
{
    public class SQLData : IAccountData
    {
        static string connectionString = "Server=localhost;Database=Account;Trusted_Connection=True;";

        static SqlConnection sqlConnection;

        public SISAccountDataService sisAccountDataService = new SISAccountDataService();

        SQLData()
        {
            sqlConnection = new SqlConnection(connectionString);
        }


        public List<SISAccount> GetAccounts()
        {
            var selectStatement = "SELECT SISAccount, SISEmail, SISPassword FROM Account";

            SqlCommand selectCommand = new SqlCommand(selectStatement, sqlConnection);
            sqlConnection.Open();
            SqlDataReader reader = selectCommand.ExecuteReader();

            var SISAccounts = new List<SISAccount>();

            while (reader.Read())
            {
                SISAccounts.Add(new SISAccount
                {
                    SISAccountNumber = reader["SISAccount"].ToString(),
                    EmailAddress = reader["SISEmail"].ToString(),
                    Password = reader["SISPassword"].ToString(),
                    DateCreated = DateTime.Now,
                    DateModified = DateTime.Now,
                    //Type =/* DateTime.Now,*/ reader["AccountType"].GetType()
                });
            }

            sqlConnection.Close();
            return SISAccounts;
            
        }


        public void SaveAccounts(SISAccount Accounts) 
        {

            var insertStatement = "INSERT INTO Account VALUES " +
                "(@SISAccount, @SISEmail, @SISPassword, @SISDateCreated, @SISDateModified, @SISType)";

            SqlCommand insertCommand = new SqlCommand(insertStatement, sqlConnection);

            insertCommand.Parameters.AddWithValue("@SISAccount", Accounts.SISAccountNumber);
            insertCommand.Parameters.AddWithValue("@SISEmail", Accounts.EmailAddress);
            insertCommand.Parameters.AddWithValue("@SISPassword", Accounts.Password);
            insertCommand.Parameters.AddWithValue("@SISDateCreated", Accounts.DateCreated);
            insertCommand.Parameters.AddWithValue("@SISDateModified", Accounts.DateModified);
            insertCommand.Parameters.AddWithValue("@SISType", Accounts.Type);

            sqlConnection.Open();
            insertCommand.ExecuteNonQuery();

            sqlConnection.Close();
        }




        public void UpdateAccounts(SISAccount Account) 
        {
            sqlConnection.Open();

            var updateStatement = $"UPDATE SISAccount SET Points = @Points WHERE StudentNumber = @StudentNumber";
            SqlCommand updateCommand = new SqlCommand(updateStatement, sqlConnection);
            updateCommand.Parameters.AddWithValue("@Password", Account.Password);
            updateCommand.Parameters.AddWithValue("@StudentNumber", Account.SISAccountNumber);

            updateCommand.ExecuteNonQuery();

            sqlConnection.Close();
        }
    }
}