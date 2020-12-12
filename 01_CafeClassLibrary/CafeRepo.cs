using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_CafeClassLibrary
{
    public class CafeRepo
    {

        private List<Cafe> _cafe = new List<Cafe>();
        
        //Create
        public void AddItemToMenu(Cafe item)
        {
            _cafe.Add(item);
        }



        //Read Menu
        public List<Cafe> GetMenuItems()
        {
            return _cafe;
        }

        //Delete item from menu

        public bool RemoveFromMenu(string name)
        {
            Cafe item = GetMenuitemByName(name);
            if (item == null)
            {
                return false;
            }
            int initialList = _cafe.Count;
            _cafe.Remove(item);
            if (initialList > _cafe.Count)
            {
                return true;
            }
            else
            {
                return false;

            }

        }

        public bool UpdateItem(string name, Cafe newItem)

        {
            //Find the item
            Cafe oldItem = GetMenuitemByName(name);
            //Update the item
            if(oldItem != null)
            {
                oldItem.MealName = newItem.MealName;
                oldItem.MealNumber = newItem.MealNumber;
                oldItem.Description = newItem.Description;
                oldItem.Ingredients = newItem.Ingredients;
                oldItem.Price = newItem.Price;
                return true;
            }
            else
            {
                return false;
            }

        }

        //Helper  Method
        public Cafe GetMenuitemByName(string name)

        {
            foreach (Cafe item in _cafe)
            {
                if (item.MealName.ToLower() == name)
                    return item;
            }
            return null; // As an else statement
        }


    }
}
