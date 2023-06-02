using System;
using System.Collections.Generic;
using AM_Rules;
using AM_Models;

namespace AM_UI
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            LoginRules login = new LoginRules();
            RegisterRules register = new RegisterRules();
            RecoverRules recover = new RecoverRules();
            SISAccount account;
            SISType accountType;
            int status;
            string ifSuccess;

            do
            {
                status = ShowOptions();
                switch (status)
                {
                    case 0: break;
                    case 1:
                    case 2:
                        int action = ShowForm();
                        switch (action)
                        {
                            case 1:
                                ifSuccess = Login(status);
                                Console.WriteLine(ifSuccess);
                                break;
                            case 2:
                                Register(status);
                                break;
                            case 3:
                                ifSuccess = Recover();
                                Console.WriteLine(ifSuccess);
                                break;
                            default:
                                Console.WriteLine("Incorrent Input.");
                                break;
                        }
                        break;
                    case 3:
                        ifSuccess = Login(status);
                        Console.WriteLine(ifSuccess);
                        break;
                    default:
                        Console.WriteLine("Incorrect input.");
                        break;
                }
            } while (status != 0);

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
            string Login(int type)
            {
                if (type == 1)
                { accountType = SISType.Student; }
                else if (type == 2)
                { accountType = SISType.Faculty; }
                else
                { accountType = SISType.Admin; }

                Console.WriteLine("\nEnter the following information: ");
                Console.Write("Account number: ");
                string username = Console.ReadLine();
                Console.Write("Password: ");
                string password = Console.ReadLine();
                account = login.Login(username, password, accountType);

                if (account != null)
                { return "Successful Login."; }
                else
                { return "Incorrect Credentials."; }
            }
            void Register(int type)
            {
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
                account = recover.FindAccountByEmail(email);

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