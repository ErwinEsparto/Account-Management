using System.Data.SqlClient;
using AM_Models;

namespace AM_Data
{
    public class SQLData : IAccountData
    {
        static string connectionString = "Data Source=DESKTOP-1LU4ECR\\SQLEXPRESS; Initial Catalog = Accounts; Integrated Security = True;";

        static SqlConnection sqlConnection;

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
                    Type = reader["SISAccountType"].ToString() == "Student" ? SISType.Student : reader["SISAccountType"].ToString() == "Faculty" ? SISType.Faculty : SISType.Admin,
                });
            }

            sqlConnection.Close();
            return SISAccounts;
            
        }


        public void SaveAccounts(SISAccount Accounts) 
        {

            var insertStatement = "INSERT INTO Account VALUES " +
                "(@SISAccount, @SISEmail, @SISPassword, @SISDateCreated, @SISDateModified, @SISAccountType)";

            SqlCommand insertCommand = new SqlCommand(insertStatement, sqlConnection);

            insertCommand.Parameters.AddWithValue("@SISAccount", Accounts.SISAccountNumber);
            insertCommand.Parameters.AddWithValue("@SISEmail", Accounts.EmailAddress);
            insertCommand.Parameters.AddWithValue("@SISPassword", Accounts.Password);
            insertCommand.Parameters.AddWithValue("@SISDateCreated", Accounts.DateCreated);
            insertCommand.Parameters.AddWithValue("@SISDateModified", Accounts.DateModified);
            insertCommand.Parameters.AddWithValue("@SISAccountType", Accounts.Type == SISType.Student ? "Student" : Accounts.Type == SISType.Faculty ? "Faculty" : "Admin");

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

        public void DeleteAccount(SISAccount Account)
        {
            sqlConnection.Open();

            var deleteStatement = "DELETE FROM Account WHERE SISAccount = @SISAccount";
            SqlCommand deleteCommand = new SqlCommand(deleteStatement, sqlConnection);
            deleteCommand.Parameters.AddWithValue("@SISAccount", Account.SISAccountNumber);

            deleteCommand.ExecuteNonQuery();

            sqlConnection.Close();
        }
    }
}