using fitness.BLL.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace fitness.BLL.Controller
{
    /// <summary>
    /// Users Controller
    /// </summary>
    public class UserController
    {
        /// <summary>
        /// App User
        /// </summary>

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
            var formatter = new BinaryFormatter();

            using (var filestream = new FileStream("users.dat", FileMode.OpenOrCreate))
            {

                if (filestream.Length > 0 && formatter.Deserialize(filestream) is List<User> users)
                {
                    return users;
                }
                else
                {
                    return new List<User>();
                }
            }
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
            var formatter = new BinaryFormatter();

            using (var filestream = new FileStream("users.dat", FileMode.OpenOrCreate))
            {
                formatter.Serialize(filestream, Users);

            }
        }

    }
}
