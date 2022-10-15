using System;
using fitness.BLL.Controller;

namespace fitnessPL_cmd
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("App is launched\n\n");


            Console.WriteLine("Enter users name");
            var name = Console.ReadLine();

            var userController = new UserController(name);
            if (userController.isNewUser)
            {
                Console.WriteLine("Enter your Gender");
                var gender = Console.ReadLine();
                DateTime birthDate = ParseDateTime();
                var weight = ParseDouble("weight");
                var height = ParseDouble("height");

                userController.SetNewUserData(gender, birthDate, weight, height);
            }

            Console.WriteLine(userController.CurrentUser);
            Console.ReadLine();
        }

        private static DateTime ParseDateTime()
        {
            DateTime birthDate;
            while (true)
            {
                Console.WriteLine("Enter your birthday date (dd.mm.yyyy)");
                if (DateTime.TryParse(Console.ReadLine(), out birthDate))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Wrong birth date format!!!");
                }
            }

            return birthDate;
        }

        private static double ParseDouble(string name)
        {
            while (true)
            {
                Console.WriteLine($"Enter {name}");
                if (double.TryParse(Console.ReadLine(), out double value))
                {
                    return value;
                }
                else
                {
                    Console.WriteLine($"Wrong name format of {name}");
                }
            }
        }
    }
}

