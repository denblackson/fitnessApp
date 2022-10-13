using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fitness.BLL.Model
{

    /// <summary>
    /// Gender
    /// </summary>


    [Serializable]
    public class Gender
    {
        /// <summary>
        /// Gender`s title
        /// </summary>
        public string Name { get; set; }


        /// <summary>
        /// Create new Gender
        /// </summary>
        /// <param name="name"> Gender`s title</param>
        /// <exception cref="ArgumentNullException"></exception>
        public Gender(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("Your name cannot be empty", nameof(name));
            }

            Name = name;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
