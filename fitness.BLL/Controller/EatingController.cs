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
    public class EatingController : ControllerBase
    {
        private const string FOODS_FILE_NAME = "foods.dat";
        private const string EATINGS_FILE_NAME = "eatings.dat";
        private readonly User user;
        public List<Food> Foods { get; }
        public Eating Eatings { get; }


        public EatingController(User user)
        {
            this.user = user ?? throw new ArgumentNullException("User cannot be null", nameof(user));
            Foods = GetAllFoods();
            Eatings = GetAllEatings();
        }

        public bool Add(string foodName, double weight)
        {
            var food = Foods.SingleOrDefault(f => f.Name == foodName);
            
        }

        private List<Eating> GetAllEatings()
        {
            return Load<List<Eating>>(EATINGS_FILE_NAME) ?? new List<Eating>();
        }

        private List<Food> GetAllFoods()
        {
            return Load<List<Food>>(FOODS_FILE_NAME) ?? new List<Food>();
        }

        private void Save()
        {
            Save(FOODS_FILE_NAME, Foods);
            Save(EATINGS_FILE_NAME, Eatings);
        }

    }
}
