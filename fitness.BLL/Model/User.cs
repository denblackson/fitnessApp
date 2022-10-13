using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fitness.BLL.Model
{
    /// <summary>
    /// User
    /// </summary>

    [Serializable]
    public class User
    {
        #region  Users Properties
        /// <summary>
        /// Name
        /// </summary>
        public string Name { get; }
        /// <summary>
        /// Gender
        /// </summary>
        public Gender Gender { get; }
        /// <summary>
        /// Birthday date
        /// </summary>
        public DateTime BirthDate { get; }
        /// <summary>
        /// User`s Weight
        /// </summary>
        public double Weight { get; set; }
        /// <summary>
        /// User`s Height
        /// </summary>
        public double Height { get; set; }
        #endregion

        /// <summary>
        /// Create new User
        /// </summary>
        /// <param name="name"> Users name</param>
        /// <param name="gender"> Users gender</param>
        /// <param name="birthDate"> Users birthday date</param>
        /// <param name="weight"> Users weight</param>
        /// <param name="height"> Users height</param>
        public User(string name,
                    Gender gender,
                    DateTime birthDate,
                    double weight,
                    double height)
        {
            #region Checking entered data


            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("Users name cannot be empty");
            }

            if (gender == null)
            {
                throw new ArgumentNullException("Users gender cannot be empty", nameof(gender));
            }

            if (birthDate < DateTime.Parse("01.01.1900") || birthDate >= DateTime.Now)
            {
                throw new ArgumentNullException("You entered wrong birthdate", nameof(birthDate));
            }

            if (weight <= 0)
            {
                throw new ArgumentException("Impossible weight", nameof(weight));

            }


            if (height <= 0)
            {
                throw new ArgumentException("Your Height can`t be less then 0", nameof(height));
            }
            #endregion

            Name = name;
            Gender = gender;
            BirthDate = birthDate;
            Weight = weight;
            Height = height;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
