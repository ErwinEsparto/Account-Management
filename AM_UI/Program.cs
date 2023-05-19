using System;
using System.Collections.Generic;
using AM_Rules;
using AM_Models;

namespace AM_UI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int status;
            do
            {
                status = ShowOptions();
                if (status == 0) { break; }
                if (status < 3 && status > 0)
                { int action = showForm();
                    if (action == 1)
                    {
                        string ifSuccess = Login(status);
                        Console.WriteLine(ifSuccess);
                        if (ifSuccess == "Successful Login.") { break; }
                    }
                    else if (action == 2)
                    {
                        registerAccount(status);
                    }
                    else if (action == 3)
                    {

                    }
                    else
                    { Console.WriteLine("Incorrect input."); }
                }
                else if (status == 3)
                {
                    string ifSuccess = Login(status);
                    Console.WriteLine(ifSuccess);
                    if (ifSuccess == "Successful Login.") { break; }
                }
                else { Console.WriteLine("Incorrent Input."); }
            } while (status != 0);

            int ShowOptions()
            {
                Console.WriteLine("\nWelcome. Are you a...?");
                Console.WriteLine("[1]STUDENT");
                Console.WriteLine("[2]TEACHER");
                Console.WriteLine("[3]ADMIN");
                Console.WriteLine("[0]EXIT");
                Console.Write("Input: ");
                int num = Convert.ToInt32(Console.ReadLine());
                return num;
            }

            int showForm()
            {
                Console.WriteLine("\n[1]Login");
                Console.WriteLine("[2]Sign Up");
                Console.WriteLine("[3]Forgot Password");
                Console.Write("Input: ");
                int num = Convert.ToInt32(Console.ReadLine());
                return num;

            }

            string Login(int type)
            {
                LoginRules rules = new LoginRules();
                string? username;
                SISType acctype;
                if (type == 1)
                {
                    acctype = SISType.Student;
                    Console.Write("\nType your student number: ");
                    username = Console.ReadLine();
                }
                else if (type == 2)
                {
                    acctype = SISType.Faculty;
                    Console.Write("\nType your faculty number: ");
                    username = Console.ReadLine();
                }
                else
                {
                    acctype = SISType.Admin;
                    Console.Write("\nType your username: ");
                    username = Console.ReadLine();
                }
                Console.Write("Type your password: ");
                string? password = Console.ReadLine();
                SISAccount? account = rules.Login(username, password, acctype);

                if (account != null)
                { return "Successful Login."; }
                else
                { return "Incorrect Credentials."; }
            }
            void registerAccount(int type)
            {
                LoginRules rules = new LoginRules();
                string? username, password, email;
                SISType acctype;
                bool format;
                Console.WriteLine("\nCreating new account...");

                do
                {
                    if (type == 1)
                    {
                        acctype = SISType.Student;
                        Console.Write("Type your student number: ");
                        username = Console.ReadLine();
                        format = rules.checkFormat(username, acctype);
                        if (format == false) { Console.WriteLine("Incorrect format."); }
                    }
                    else
                    {
                        acctype = SISType.Faculty;
                        Console.Write("Type your faculty number: ");
                        username = Console.ReadLine();
                        format = rules.checkFormat(username, acctype);
                        if (format == false) { Console.WriteLine("Incorrect format."); }
                    }
                } while (format == false);

                Console.Write("Type your email address: ");
                email = Console.ReadLine();
                Console.Write("Type your password: ");
                password = Console.ReadLine();
                Console.WriteLine("Successfully Registered.");
                rules.createAccount(username, password, email, acctype);
            }
        }
    }
}