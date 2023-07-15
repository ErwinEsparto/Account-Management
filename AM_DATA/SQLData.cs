using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using AM_Models;

namespace AM_Data
{
    public class SQLData : IAccountData
    {
        static string connectionString = "Data Source=DESKTOP-C0CK3NP\\SQLEXPRESS; Initial Catalog = Accounts; Integrated Security = True;";

        static SqlConnection sqlConnection;

        //public SISAccountDataService sisAccountDataService = new SISAccountDataService();

        public SQLData()
        {
            sqlConnection = new SqlConnection(connectionString);
        }


        public List<SISAccount> GetAccount()
        {
            var selectStatement = "SELECT * FROM Account";

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
                    DateCreated = Convert.ToDateTime(reader["SISDateCreated"]),
                    DateModified = Convert.ToDateTime(reader["SISDateModified"]),
              
                    //Type = Enum.Parse(SISType, reader["SISPassword"].ToString()),
                    //Type = Parse(Type SISType, reader["AccountType"]).ToString()
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

            var updateStatement = $"UPDATE Account SET SISPassword = @SISPassword WHERE SISEmail = @SISEmail";
            SqlCommand updateCommand = new SqlCommand(updateStatement, sqlConnection);
            updateCommand.Parameters.AddWithValue("@SISPassword", Account.Password);
            updateCommand.Parameters.AddWithValue("@SISEmail", Account.EmailAddress);

            updateCommand.ExecuteNonQuery();

            sqlConnection.Close();
        }
    }
}