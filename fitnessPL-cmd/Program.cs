using System;
using fitness.BLL.Controller;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fitnessPL_cmd
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("App is launched");
            Console.WriteLine("Enter users name");
            var name = Console.ReadLine();

            Console.WriteLine("Enter your Gender");
            var gender = Console.ReadLine();

            Console.WriteLine("Enter your birth date");
            var birthdate = DateTime.Parse(Console.ReadLine()); // TODO: tryparse

            Console.WriteLine("Enter your weight");
            var weighte = double.Parse(Console.ReadLine());

            Console.WriteLine("Enter your height");
            var height = double.Parse(Console.ReadLine());


            var userController = new UserController(name, gender, birthdate, height, weighte);
            userController.Save();

            //

        }
    }
}
