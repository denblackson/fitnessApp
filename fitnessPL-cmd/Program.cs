using System;
using System.Globalization;
using System.Resources;
using System.Xml.Linq;
using fitness.BLL.Controller;
using fitness.BLL.Model;


namespace fitnessPL_cmd
{
    class Program
    {
        static void Main(string[] args)
        {
            var culture = CultureInfo.CreateSpecificCulture("en-us");
            //var culture = CultureInfo.CreateSpecificCulture("ru-RU");
            //var culture = CultureInfo.CreateSpecificCulture("uk-UA");


            var resourceManager = new ResourceManager("fitnessPL_cmd.Languages.Messages", typeof(Program).Assembly);



            Console.WriteLine(resourceManager.GetString("Launched", culture));

            Console.WriteLine(resourceManager.GetString("EnterName", culture));
            var name = Console.ReadLine();

            var userController = new UserController(name);
            var eatingController = new EatingController(userController.CurrentUser);
            var exerciseController = new ExerciseController(userController.CurrentUser);

            if (userController.IsNewUser)
            {
                Console.WriteLine(resourceManager.GetString("EnterGender", culture));
                Console.WriteLine("EnterGender");
                var gender = Console.ReadLine();
                var birthDate = ParseDateTime("birthday date ");
                var usersWeight = ParseDouble("your weight ");
                var usersHeight = ParseDouble("your height");

                userController.SetNewUserData(gender, birthDate, usersWeight, usersHeight);
            }
            Console.WriteLine(userController.CurrentUser);




            while (true)
            {
                Console.WriteLine(resourceManager.GetString("WhatDoUWant?", culture));
                Console.WriteLine(resourceManager.GetString("E-EnterNewMeal", culture));
                Console.WriteLine(resourceManager.GetString("A-EnterNewExercise", culture));
                Console.WriteLine(resourceManager.GetString("Q-Exit", culture));
                var key = Console.ReadKey();
                Console.WriteLine();

                switch (key.Key)
                {
                    case ConsoleKey.E:
                        var foods = EnterEating();
                        eatingController.Add(foods.Food, foods.Weight);

                        foreach (var item in eatingController.Eating.Foods)
                        {
                            Console.WriteLine($"\t{item.Key} - {item.Value}");
                        }
                        break;
                    case ConsoleKey.A:
                        var exer = EnterExercise();
                        //var exercise = new Exercise(exer.Begin,exer.End, exer.Activity, userController.CurrentUser);
                        exerciseController.Add(exer.Activity, exer.Begin, exer.End);

                        foreach (var item in exerciseController.Exercises)
                        {
                            Console.WriteLine($"\t{item.Activity} since {item.Start.ToShortTimeString()} to {item.Finish.ToShortTimeString()}");
                        }
                        break;
                    case ConsoleKey.Q:
                        Environment.Exit(0);
                        break;
                    default:
                        break;
                }
                Console.ReadLine();
            }
        }

        private static (DateTime Begin, DateTime End, Activity Activity) EnterExercise()
        {
            Console.WriteLine("Enter the name of exercise: ");
            var name = Console.ReadLine();

            var energy = ParseDouble("energy consumption per min");

            var begin = ParseDateTime("Start");
            var end = ParseDateTime("finish");

            var activity = new Activity(name, energy);
            return (begin, end, activity);
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

        private static DateTime ParseDateTime(string value)
        {
            DateTime birthDate;
            while (true)
            {
                Console.WriteLine($"Enter {value} (dd.mm.yyyy): ");
                if (DateTime.TryParse(Console.ReadLine(), out birthDate))
                {
                    break;
                }
                else
                {
                    Console.WriteLine($"Wrong {value} format!!!");
                }
            }

            return birthDate;
        }

        private static double ParseDouble(string name)
        {
            while (true)
            {
                Console.WriteLine($"Enter {name}: ");
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

