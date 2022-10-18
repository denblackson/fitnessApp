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
    public class ExerciseControllerTests
    {
        [TestMethod()]
        public void AddTest()
        {
            // Arrange
            var userName = Guid.NewGuid().ToString();
            var activitiyName = Guid.NewGuid().ToString();
            var rnd = new Random();
            var userController = new UserController(userName);
            var exerciseController = new ExerciseController(userController.CurrentUser);
            var activity = new Activity(activitiyName, rnd.Next(10, 50));
            // Act
            exerciseController.Add(activity, DateTime.Now, DateTime.Now.AddHours(1));
            //Assert
            Assert.AreEqual(activity.Name, exerciseController.Activities.First().Name);
        }
    }
}
