using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_CafeClassLibrary
{
    public class Cafe
    {
        public int MealNumber { get; set; }
        public string MealName { get; set; }
        public string Description { get; set; }
        public List<string> Ingredients { get; set; }
        public double Price{ get; set; }

        public Cafe() { }

        public Cafe(string mealname, string description, int mealnumber, double price,List<string> ingredients)
        {
            MealNumber = mealnumber;
            MealName = mealname;
            Description = description;
            Ingredients = ingredients;
            Price = price;
        }
    }
}
