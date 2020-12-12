﻿using _01_CafeClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_CafeConsoleApp
{
    public class CafeProgramUI
    {
        public Cafe _cafe = new Cafe();
        public CafeRepo _caferepo = new CafeRepo();
        
        public void Run()
        {
            SeedItemList();
            Menu();
            
             
        }
        private void Menu()
        {
            bool KeepRunning = true;
            while (KeepRunning)
            {
                Console.WriteLine("Select a menu Option:\n" +
                    "     " + "1.Create a new menu item.\n" +
                    "     " + "2.Delete a menu item.\n" +
                    "     " + "3.Update the menu item.\n" +
                    "     " + "4.View  all items on the cafe's menu.\n" +
                    "     " + "5.Exit.\n");

                string input = Console.ReadLine();

                //Evaluate the user input and act accordingly
                Console.Clear();
                switch (input)
                {
                    case "1":
                        CreateMenuItem();
                        break;
                    case "2":
                        DeleteMenuItem();
                        break;
                    case "3":
                        UpdateMenuItem();
                        break;
                    case "4":
                        DisplayAllItems();
                        break;
                    case "5":
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine("GoodBye!\n");
                        Console.ResetColor();
                        KeepRunning = false;

                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Please Enter a Valid Number.\n");
                        Console.ResetColor();
                        break;

                }
                Console.WriteLine("Please enter any key to continue");
                Console.ReadKey();
                Console.Clear();

            }
        }
        //create a new menu item
        public void CreateMenuItem()
        {
            //MealName

            Console.WriteLine("Enter the name of the new meal");

            _cafe.MealName = Console.ReadLine();

            //MealNumber
            Console.WriteLine("Enter the number of the new meal");
            _cafe.MealNumber = int.Parse(Console.ReadLine());

            //Description

            Console.WriteLine("Enter the description of the new meal");
            _cafe.Description = Console.ReadLine();

            //List of ingredient

            Console.WriteLine("Enter the ingredients of the meal");
            _cafe.Ingredients = Console.ReadLine();

            //Price
            Console.WriteLine("Enter the price of the new meal");
            string doubleAsString= Console.ReadLine();
            double doubleAsdouble = double.Parse(doubleAsString);
            
            Console.ForegroundColor = ConsoleColor.Green;

            Console.WriteLine("The menu item was successfuly added to the list\n");
            Console.ResetColor();
            _caferepo.AddItemToMenu(_cafe);
            

        }


        
        //Delete a menu item
        public void DeleteMenuItem()
        {
            DisplayAllItems();
            Console.WriteLine("Enter the name of the meal that you'd like to remove.\n");
            string input = Console.ReadLine();
           bool wasDeleted=_caferepo.RemoveFromMenu(input);

            if (wasDeleted == true)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("The menu item was successfuly deleted\n\n"); 
                Console.ResetColor();
            }
            else
            {
                Console.WriteLine("The item could not be deleted");
            }
            _caferepo.RemoveFromMenu(input);
        }
        //See the list of all items

        public void DisplayAllItems()
        {
            List<Cafe> listofitems = _caferepo.GetMenuItems();
            foreach(Cafe item in listofitems)
            {
                Console.WriteLine($"Meal Name:{item.MealName}\n" +
                    $"Meal number:{item.MealNumber}\n" +
                    $"Description:{item.Description}\n" +
                    $"Ingredients:{item.Ingredients}\n" +
                    $"Price:${item.Price}\n");
            }
        }
        //Update a menu item

        public void UpdateMenuItem()

        {

            // Display our Menu
            DisplayAllItems();

            Cafe newItem = new Cafe();

            //Ask for the  Item to update
            Console.WriteLine("Enter the name of the item that you'd like to update.\n");

            //Get that item
            string oldname = Console.ReadLine();

            //buit a new one
            Console.WriteLine("Enter the  new name of the item.\n");

            newItem.MealName = Console.ReadLine();

            //MealNumber
            Console.WriteLine("Enter the new number of the item\n");
            newItem.MealNumber = int.Parse(Console.ReadLine());

            //Description

            Console.WriteLine("Enter the new description of the item\n");
            newItem.Description = Console.ReadLine();

            //List of ingredient

            Console.WriteLine("Enter the new ingredients of the item\n");
            newItem.Ingredients = Console.ReadLine();

            //Price
            Console.WriteLine("Enter the  new price of the item\n");
           string doubleAsString = Console.ReadLine();
            newItem.Price = double.Parse(doubleAsString);
            
            // Verify if it's updated

          bool wasUpdated=  _caferepo.UpdateItem(oldname, newItem);
            if (wasUpdated)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Your item was successfully updated\n");
               
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Could not Update the item.");
                Console.ResetColor();
            }

        }



        private void SeedItemList()
        {
            
            Cafe Espresso = new Cafe("Espresso", "full-flavored concentrated form of coffe that is served in shots", 1, 3, "Coffe beans");
            Cafe Latte = new Cafe("Latte", "espresso mixed with hot or steamed milk", 2, 1.5, "milk,espresso,thin layer of foam");
            Cafe Donuts = new Cafe("Donuts", "Fried dough connection or desert food", 3,2.5, "flour,baking powder,salt,liquid,eggs,milk,sugar,some flavors");
            _caferepo.AddItemToMenu(Espresso);
            _caferepo.AddItemToMenu(Latte);
            _caferepo.AddItemToMenu(Donuts);
        }









    }
}
