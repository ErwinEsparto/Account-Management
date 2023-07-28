using AM_Rules;
using AM_Models;
using Microsoft.IdentityModel.Tokens;

namespace AM_UI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            LoginRules login = new LoginRules();
            RegisterRules register = new RegisterRules();
            RecoverRules recover = new RecoverRules();
            AdminRules admin = new AdminRules();

            int status = ShowOptions();
            bool isLoginSuccess;
            switch (status)
            {
                case 0: break;
                case 1:
                case 2:
                    int action = ShowForm();
                    switch (action)
                    {
                        case 1:
                            isLoginSuccess = Login(status);
                            if (isLoginSuccess == true && status == 1)
                            { Console.WriteLine("Successful Login. Show Student Profile here."); }
                            else if (isLoginSuccess == true && status == 2)
                            { Console.WriteLine("Successful Login. Show Faculty Profile here."); }
                            else
                            { Console.WriteLine("Incorrect Credentials."); }
                            break;
                        case 2:
                            Register(status);
                            break;
                        case 3:
                            string isRecoverSuccess = Recover(status);
                            Console.WriteLine(isRecoverSuccess);
                            break;
                        default:
                            Console.WriteLine("Incorrent Input.");
                        break;
                    }
                break;
                case 3:
                    isLoginSuccess = Login(status);
                    if (isLoginSuccess == true && status == 3)
                    { Console.WriteLine("Successful Login."); }
                    else
                    { Console.WriteLine("Incorrect Credentials."); break; }

                    int adminAction = ShowAdminForm();
                    switch (adminAction)
                    {
                        case 1:
                        case 2:
                            ViewAccounts(adminAction);
                            break;
                        case 3:
                            Console.WriteLine("\nSearching account...");
                            Console.Write("Enter the account number: ");
                            string SearchAccountNumber = Console.ReadLine();
                            SearchAccount(SearchAccountNumber);
                            break;
                        case 4:
                            Console.WriteLine("\nWARNING! Deleting account...");
                            Console.Write("Enter the account number: ");
                            string DeleteAccountNumber = Console.ReadLine();
                            string isDeleteSuccess = DeleteAccount(DeleteAccountNumber);
                            Console.WriteLine(isDeleteSuccess);
                            break;
                        default:
                            Console.WriteLine("Incorrect input.");
                            break;
                    }
                    break;
                default:
                    Console.WriteLine("Incorrect input.");
                break;
            }

            int ShowOptions()
            {
                Console.Write("Press any key to continue.");
                Console.ReadKey();
                Console.Clear();
                Console.WriteLine("Welcome. Are you a...?");
                Console.WriteLine("[1]STUDENT");
                Console.WriteLine("[2]TEACHER");
                Console.WriteLine("[3]ADMIN");
                Console.WriteLine("[0]EXIT");
                Console.Write("Input: ");
                return Convert.ToInt32(Console.ReadLine());
            }
            int ShowForm()
            {
                Console.WriteLine("\nPlease choose an action: ");
                Console.WriteLine("[1]Login");
                Console.WriteLine("[2]Sign Up");
                Console.WriteLine("[3]Forgot Password");
                Console.Write("Input: ");
                return Convert.ToInt32(Console.ReadLine());
            }
            int ShowAdminForm()
            {
                Console.WriteLine("\nPlease choose an action: ");
                Console.WriteLine("[1]View student accounts");
                Console.WriteLine("[2]View faculty accounts");
                Console.WriteLine("[3]Search an account");
                Console.WriteLine("[4]Delete an account");
                Console.Write("Input: ");
                return Convert.ToInt32(Console.ReadLine());
            }
            bool Login(int type)
            {
                SISType accountType = type == 1 ? SISType.Student : type == 2 ? SISType.Faculty : SISType.Admin;
                
                Console.WriteLine("\nEnter the following information: ");
                Console.Write("Account number: ");
                string username = Console.ReadLine();
                Console.Write("Password: ");
                string password = Console.ReadLine();

                SISAccount account = login.Login(username, password, accountType);
                return account != null ? true : false;
            }
            void Register(int type)
            {
                SISType accountType;
                string username, password, email;
                bool format;
                Console.WriteLine("\nCreating new account...");

                if (type == 1)
                { accountType = SISType.Student; }
                else
                { accountType = SISType.Faculty; }

                do
                {
                    Console.Write("Account number: ");
                    username = Console.ReadLine();
                    format = register.CheckFormat(username, accountType);
                    if (format == false) { Console.WriteLine("Incorrect Account Number format."); }
                } while (format == false);

                Console.Write("Email address: ");
                email = Console.ReadLine();
                Console.Write("Password: ");
                password = Console.ReadLine();
                
                register.CreateAccount(username, email, password, accountType);
                Console.WriteLine("Successfully Registered.");
            }
            string Recover(int type)
            {
                SISType accountType = type == 1 ? SISType.Student : SISType.Faculty;
                Console.WriteLine("\nRecovering Account...");
                Console.Write("Please enter your email: ");
                string email = Console.ReadLine();
                SISAccount account = recover.FindAccountByEmail(email, accountType);

                if (account != null)
                {
                    Console.WriteLine("\nAccount Found!");
                    Console.Write("Type your new password: ");
                    string newPassword = Console.ReadLine();
                    Console.Write("Type your new password again: ");
                    string newPassword2 = Console.ReadLine();

                    bool result = recover.RecoverSISAccountByEmail(email, newPassword, newPassword2, accountType);
                    return result == true ? "Successfully recovered your account." : "Password are not the same.";
                }
                else
                { return "Account not found."; }
            }
            void ViewAccounts(int adminAction)
            {
                SISType accountType = adminAction == 1 ? SISType.Student : SISType.Faculty;
                List<SISAccount> accounts = admin.GetAccounts(accountType);
                foreach (SISAccount account in accounts)
                {
                    Console.WriteLine("\nAccount Number: " + account.SISAccountNumber);
                    Console.WriteLine("Email Address: " + account.EmailAddress);
                    Console.WriteLine("Date Created: " + account.DateCreated);
                    Console.WriteLine("Date Modified: " + account.DateModified);
                }
            }
            void SearchAccount(string accountNumber)
            {
                SISAccount account = admin.SearchAccount(accountNumber);
                if (account != null)
                {
                    Console.WriteLine("\nAccount Found!");
                    Console.WriteLine("Account Number: " + account.SISAccountNumber);
                    Console.WriteLine("Email Address: " + account.EmailAddress);
                    Console.WriteLine("Account Type: " + account.Type);
                    Console.WriteLine("Date Created: " + account.DateCreated);
                    Console.WriteLine("Date Modified: " + account.DateModified);
                }
                else
                {
                    Console.WriteLine("Account not found.");
                }
            }
            string DeleteAccount(string accountNumber)
            {
                bool result = admin.DeleteAccount(accountNumber);

                if (result == true)
                { return "Successfully deleted account."; }
                else
                { return "Account not found."; }
            }
        }
    }
}