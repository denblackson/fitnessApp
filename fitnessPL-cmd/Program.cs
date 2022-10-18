using System;
using System.Xml.Linq;
using fitness.BLL.Controller;
using fitness.BLL.Model;

namespace fitnessPL_cmd
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("App is launched\n\n");

            Console.WriteLine("Enter your name");
            var name = Console.ReadLine();

            var userController = new UserController(name);
            var eatingController = new EatingController(userController.CurrentUser);
            if (userController.isNewUser)
            {
                Console.WriteLine("Enter your Gender: ");
                var gender = Console.ReadLine();
                var birthDate = ParseDateTime();
                var usersWeight = ParseDouble("wour weight ");
                var usersHeight = ParseDouble("your height");

                userController.SetNewUserData(gender, birthDate, usersWeight, usersHeight);
            }


            Console.WriteLine(userController.CurrentUser);

            Console.WriteLine("What do u want?");
            Console.WriteLine("E - enter new meal");
            var key = Console.ReadKey();
            Console.WriteLine();

            if (key.Key == ConsoleKey.E)
            {
                var foods = EnterEating();
                eatingController.Add(foods.Food, foods.Weight);

                foreach (var item in eatingController.Eating.Foods)
                {
                    Console.WriteLine($"\t{item.Key} - {item.Value}");
                }
            }

            Console.ReadLine();
        }

        private static (Food Food, double Weight) EnterEating()
        {
            Console.Write("Enter product name: ");
            var food = Console.ReadLine();

            var calories = ParseDouble("Calories");
            var prots = ParseDouble("proteins");
            var fats = ParseDouble("fats");
            var carbs = ParseDouble("Carbohydrates");

            var weight = ParseDouble("portion weight");
            var product = new Food(food, calories, prots, fats, carbs);


            return (Food: product, Weight: weight);
        }

        private static DateTime ParseDateTime()
        {
            DateTime birthDate;
            while (true)
            {
                Console.WriteLine("Enter your birthday date (dd.mm.yyyy): ");
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
                Console.WriteLine($"Enter {name}: ");
                if (double.TryParse(Console.ReadLine(), out double value))
                {
                    return value;
                }
                else
                {
                    Console.WriteLine($"Wrong format of {name}");
                }
            }
        }
    }
}

