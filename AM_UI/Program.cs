using System;
using System.Collections.Generic;
using AM_Rules;

namespace AM_UI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            List<string> options = new List<string>()
            {"Welcome. Are you a...?", "[1]STUDENT", "[2]TEACHER", "[3]ADMIN", "[0]EXIT"};
            List<string> forms = new List<string>()
            {"\n[1]Login", "[2]Sign Up", "[3]Forgot Password"};


            int status = ShowOptions();
            if (status == 1)
            {
                int action = showForm();

            }
            else if (status == 2)
            {
                int action = showForm();

            }
            if (status == 3)
            {
                adminLogin();
            }

            int ShowOptions()
            {
                foreach (string option in options)
                {
                    Console.WriteLine(option);
                }
                Console.Write("Input: ");
                int num = Convert.ToInt32(Console.ReadLine());
                return num;
            }

            int showForm()
            {
                foreach (string form in forms)
                {
                    Console.WriteLine(form);
                }
                Console.Write("Input: ");
                int num = Convert.ToInt32(Console.ReadLine());
                return num;

            }

            void adminLogin()
            {
                AdminRules r = new AdminRules();
                Console.Write("\nType your email: ");
                string adminEmail = Console.ReadLine();
                Console.Write("Type your password: ");
                string adminPass = Console.ReadLine();
                bool check = r.checkAdminAccount(adminEmail, adminPass);

                if (check == true)
                {
                    Console.WriteLine("Successful Login.");
                }
                else
                {
                    Console.WriteLine("Incorrect credentials.");
                }
            }
        }
    }
}