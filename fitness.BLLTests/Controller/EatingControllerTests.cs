using Microsoft.VisualStudio.TestTools.UnitTesting;
using fitness.BLL.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using fitness.BLL.Model;

namespace fitness.BLL.Controller.Tests
{
    [TestClass()]
    public class EatingControllerTests
    {
        [TestMethod()]
        public void AddTest()
        {

            // проходить тільки якшо тестовий юхер буде першим


            // Arrange
            var userName = Guid.NewGuid().ToString();
            var foodName  = Guid.NewGuid().ToString();
            var rnd = new Random();
            var userController = new UserController(userName);
            var eatingController = new EatingController(userController.CurrentUser);
            var food = new Food(foodName, rnd.Next(10, 500), rnd.Next(50, 500), rnd.Next(50, 500), rnd.Next(50, 500));
            // Act
            eatingController.Add(food, 100);
            //Assert
            Assert.AreEqual(food.Name,eatingController.Eating.Foods.First().Key.Name);
        }
    }
}