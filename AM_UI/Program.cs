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
                            string isRecoverSuccess = Recover();
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
                    { Console.WriteLine("Successful Login. Show Admin Profile here."); }
                    else
                    { Console.WriteLine("Incorrect Credentials."); }
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
            string Recover()
            {
                Console.WriteLine("\nRecovering Account...");
                Console.Write("Please enter your email: ");
                string email = Console.ReadLine();
                SISAccount account = recover.FindAccountByEmail(email);

                if (account != null)
                {
                    Console.WriteLine("\nAccount Found!");
                    Console.Write("Type your new password: ");
                    string newPassword = Console.ReadLine();
                    Console.Write("Type your new password again: ");
                    string newPassword2 = Console.ReadLine();
                    bool result = recover.RecoverSISAccountByEmail(email, newPassword, newPassword2);
                    
                    if(result == true)
                    { return "Successfully recovered your account."; }
                    else { return "Password are not the same."; }
                }
                else
                { return "Account not found."; }
            }
        }
    }
}