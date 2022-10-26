using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fitness.BLL.Model
{
    /// <summary>
    /// eating meal
    /// </summary>
     [Serializable]
    public class Eating
    {

        public int Id { get; set; }

        /// <summary>
        /// час прийому їди
        /// </summary>
        public DateTime Moment { get; set; }

        /// <summary>
        /// Eaten kinds of food
        /// 
        /// Dictionary<Food, double>    <Foodtype,quantity >
        /// 
        /// </summary>
        public Dictionary<Food, double> Foods { get; set; }

        public int UserId { get; set; }
        public virtual User User { get; set; }


        public Eating(User user)
        {

            User = user ?? throw new ArgumentNullException("User cannot be null", nameof(user));
            Moment = DateTime.UtcNow;
            Foods = new Dictionary<Food, double>();
        }

        public Eating()
        {
                
        }
        /// <summary>
        /// Add one meal
        /// </summary>
        /// <param name="food"></param> type of food
        /// <param name="weight"></param> quantity
        public void Add(Food food, double weight)
        {
            var product = Foods.Keys.FirstOrDefault(f => f.Name.Equals(food.Name));

            if (product == null)
            {
                Foods.Add(food, weight);
            }
            else
            {
                Foods[product] +=weight;
            }
        }
    }
}
