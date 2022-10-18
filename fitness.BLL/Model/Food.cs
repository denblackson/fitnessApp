using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fitness.BLL.Model
{
    [Serializable]
    public class Food
    {
        public string Name { get; set; }
        /// <summary>
        /// Proteins
        /// </summary>

        public double Proteins { get; }
        /// <summary>
        /// Fats
        /// </summary>

        public double Fats { get; }
        /// <summary>
        /// Carbohydrates
        /// </summary>

        public double Carbohydrates { get; }

        /// <summary>
        /// Calories per 100 gramm
        /// </summary>івфів
        public double Calories { get; }





        public Food(string name, double proteins, double fats, double carbohydrates, double calories)
        {
            // TODO: check

            Name = name;
            Proteins = proteins / 100.0;
            Fats = fats / 100.0;
            Carbohydrates = carbohydrates / 100.0;
            Calories = calories / 100.0;
        }



        public Food(string name) : this(name, 0, 0, 0, 0) { }


        public override string ToString()
        {
            return Name;
        }
    }
}
