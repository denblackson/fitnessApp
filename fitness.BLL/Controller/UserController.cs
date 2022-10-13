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
    //
    /// <summary>
    /// Users Controller
    /// </summary>
    public class UserController
    {
        /// <summary>
        /// App User
        /// </summary>
        public User User { get; }
        /// <summary>
        /// Creation of new User
        /// </summary>
        /// <param name="user">Users name</param>
        /// <exception cref="ArgumentException"></exception>
        public UserController(string userName, string genderName, DateTime birthDay, double weight, double height)
        {
            var gender = new Gender(genderName);
            User = new User(userName, gender, birthDay, weight, height);
        }

        /// <summary>
        /// Get users data
        /// </summary>
        /// <returns>app user</returns>
        /// <exception cref="FileLoadException"></exception>
        public UserController()
        {
            var formatter = new BinaryFormatter();

            using (var filestream = new FileStream("users.dat", FileMode.OpenOrCreate))
            {
                if (formatter.Deserialize(filestream) is User user)
                {
                    User = user;
                }

                // TODO: if user failed to read
            }
        }
        /// <summary>
        /// Save Users data
        /// </summary>
        public void Save()
        {
            var formatter = new BinaryFormatter();

            using (var filestream = new FileStream("users.dat", FileMode.OpenOrCreate))
            {
                formatter.Serialize(filestream, User);

            }
        }

    }
}
