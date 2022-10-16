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
        /// App User
        /// </summary>

        private const string USERS_FILE_NAME = "users.dat";
        public List<User> Users { get; }
        public User CurrentUser { get; }

        public bool isNewUser { get; } = false;


        /// <summary>
        /// Creation of new User controller
        /// </summary>
        /// <param name="user">Users name</param>
        /// <exception cref="ArgumentException"></exception>
        public UserController(string userName)
        {
            if (string.IsNullOrWhiteSpace(userName))
            {
                throw new ArgumentNullException("Users name cannot be empty", nameof(userName));
            }

            Users = GetUsersData();

            CurrentUser = Users.SingleOrDefault(u => u.Name == userName); // return null if failed to find user

            if (CurrentUser == null)
            {
                CurrentUser = new User(userName);
                Users.Add(CurrentUser);
                isNewUser = true;
                Save();
            }
        }


        /// <summary>
        /// Get saved users List
        /// </summary>
        /// <returns></returns>
        private List<User> GetUsersData()
        {
           return Load<List<User>>(USERS_FILE_NAME) ?? new List<User>();
        }



        public void SetNewUserData(string genderName, DateTime birthdate,
                                   double weight = 1, double height = 1)
        {
            CurrentUser.Gender = new Gender(genderName);
            CurrentUser.BirthDate = birthdate;
            CurrentUser.Weight = weight;
            CurrentUser.Height = height;
            Save();
        }
        /// <summary>
        /// Save Users data
        /// </summary>
        public void Save()
        {
            Save(USERS_FILE_NAME, Users);
        }

    }
}
