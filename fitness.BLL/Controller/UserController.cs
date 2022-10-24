using fitness.BLL.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace fitness.BLL.Controller
{
    /// <summary>
    /// Users Controller
    /// </summary>
   
    public class UserController : ControllerBase
    {
        /// <summary>
        /// Пользователь приложения.
        /// </summary>
        public List<User> Users { get; }

        public User CurrentUser { get; }

        public bool IsNewUser { get; } = false;

        /// <summary>
        /// Create new users controller
        /// </summary>
        /// <param name="user"></param>
        public UserController(string userName)
        {
            if (string.IsNullOrWhiteSpace(userName))
            {
                throw new ArgumentNullException("Users name cannot be null", nameof(userName));
            }

            Users = GetUsersData();

            CurrentUser = Users.SingleOrDefault(u => u.Name == userName);

            if (CurrentUser == null)
            {
                CurrentUser = new User(userName);
                Users.Add(CurrentUser);
                IsNewUser = true;
            }
        }

        /// <summary>
        /// Get saved users List
        /// </summary>
        /// <returns></returns>
        private List<User> GetUsersData()
        {
            return Load<User>() ?? new List<User>();
        }


        public void SetNewUserData(string genderName, DateTime birthDate, double weight = 1, double height = 1)
        {
            // Checks

            CurrentUser.Gender = new Gender(genderName);
            CurrentUser.BirthDate = birthDate;
            CurrentUser.Weight = weight;
            CurrentUser.Height = height;
            Save();
        }

        /// <summary>
        /// Save users data
        /// </summary>
        public void Save()
        {
            Save(Users);
        }
    }
}
