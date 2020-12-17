using _03_BadgesClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_BadgesConsoleApp
{
    public class BadgesProgramUI
    {
        
      //New up an instance for our repo and badge class
        public Badges _badges = new Badges();
        public BadgesRepo _badgesrepo = new BadgesRepo();
        public List<string> badgeDoor = new List<string>();

        public void Run()
        {
             
            SeeDListOfBadges();
            Menu();
           
        }
        public void Menu()
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("                                         Komodo Insurance");
                Console.ResetColor();
                Console.WriteLine("                                        -------------------\n");
                Console.WriteLine("Choose a menu option:\n" +
                    "---------------------\n" +
                "                1.Add a badge.\n" +
                "                2.Edit a badge.\n" +
                "                3.List all badges.\n" +
                "                4.Exit.");
                

                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        AddNewBadgeToList();
                        break;
                    case "2":
                        UpdateBadge();
                        break;
                    case "3":
                        DisplayAllBadges();
                        break;

                    case "4":
                        keepRunning = false;
                
                        break;
                    default:
                        Console.WriteLine("Please enter a valid number");
                        break;
  
                }
                Console.WriteLine("Press any key to continue");
                Console.ReadKey();
                Console.Clear();
            }
        }

     


        public void AddNewBadgeToList()
        {
            Console.Clear();
            List<string> doorlist = new List<string>();
            Badges badge = new Badges();

            Console.WriteLine("Enter ID of the badge.\n");
            string stringAsInt = Console.ReadLine();
            badge.BadgeId = int.Parse(stringAsInt);

            bool addingDoors = true;
            while (addingDoors)// While loop to keep running as long as the user needs to add doors to the new badge.
            {
                Console.WriteLine("List a door it needs access to:\n");
                doorlist.Add(Console.ReadLine());// Add the door to the list of doors

                Console.WriteLine("Any other doors it needs access to? Yes/No ");
                string anyotherdoor = Console.ReadLine().ToLower();
               
                if (anyotherdoor == "no")
                {
                  
                    break;
                }
              

            }
            badge.DoorName = doorlist;
            _badgesrepo.CreateNewBadge(badge.BadgeId, doorlist);// Call  CreateNewBadge from my repo

           
        }


        public void DisplayAllBadges()
        {

            Console.Clear();

            Dictionary<int, List<string>> dictionary = _badgesrepo.GetAllBadges();

            foreach (KeyValuePair<int, List<string>> keyvaluepair in dictionary)
            {

                // pull  ID from badge
                Console.WriteLine("\n");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Badge #" +" "+ keyvaluepair.Key + " "+ "has access to :");
                Console.ResetColor();

                Console.ForegroundColor = ConsoleColor.DarkGreen; 
                Console.WriteLine("================================\n");
                Console.ResetColor();
                //pull List<string>(doors) from badge
                foreach (string x in keyvaluepair.Value)
                {
                    Console.WriteLine("Door:"+" "+x);
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.WriteLine("=====");
                    Console.ResetColor();
                    
                }

            }

            

        }


        public void UpdateBadge()
        {
            
            DisplayAllBadges();
            Console.WriteLine("\n");
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("Press any key to start the update.");
            Console.ResetColor();
            Console.WriteLine("=================================\n");
            Console.ReadKey();
            
            Console.WriteLine("Enter the badge ID that you'd like to apdate:\n");
            int ID =Convert.ToInt32 (Console.ReadLine());//Convert from string to int
           
            Badges updatebadge = _badgesrepo.GetBadgeById(ID);// call my GetbadgeById from my repo
            if (updatebadge != null)// Make sure the badge exists
            {
                badgeDoor = updatebadge.DoorName;// Assign BadgeDoor
                bool KeepRunning = true;// I want my app to run as long as I want to add or remove doors from badge.
                while (KeepRunning)
                {

                    Console.Clear();
                    
                    
                    string doors = string.Join(",", updatebadge.DoorName);// Use join method to bring our doors one by one, and combine them to get many string members(list<string>).(separate them by comma)
                    Console.WriteLine($"Badge #{updatebadge.BadgeId} has access to doors: {doors}\n");//call my badge with its doors
                    Console.WriteLine("What would you like to do?\n");
                    Console.WriteLine("     1.Add a door");
                    Console.WriteLine("     2.Remove a door");
                    Console.WriteLine("     3.Exit\n");
                    string input = Console.ReadLine();
                    switch (input)
                    {
                        case "1":
                            Console.WriteLine("Enter the name of the door that you'd like to add.");
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.WriteLine("====================================================");
                            Console.ResetColor();
                            string doorToAdd = Console.ReadLine();
                            badgeDoor.Add(doorToAdd);// Add the door to list
                            badgeDoor = updatebadge.DoorName; //Assign BadgeDoor
                            doors = string.Join(",", updatebadge.DoorName);// Use join method to bring our doors one by one and add them to the badge that we called before.
                            Console.ForegroundColor = ConsoleColor.DarkGreen;
                            Console.WriteLine("Your door was successfuly  Added to the badge\n");
                            Console.ResetColor();
                            Console.WriteLine($"Badge #{updatebadge.BadgeId} has access to doors: {doors}.");//call my badge with its doors
                            Console.ForegroundColor = ConsoleColor.DarkGreen;
                            Console.WriteLine("===================================\n");
                            Console.ResetColor();
                            Console.WriteLine("Press any key to continue.");
                            Console.ReadKey();


                            break;
                        case "2":


                            Console.WriteLine("Enter the name of the door that you'd like to remove.");
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.WriteLine("====================================================");
                            Console.ResetColor();
                            string input1 = Console.ReadLine();
                            badgeDoor.Remove(input1);
                            Console.ForegroundColor = ConsoleColor.DarkRed;
                            Console.WriteLine("Your door was successfuly  removed  from the badge\n");
                            Console.ResetColor();
                            badgeDoor = updatebadge.DoorName;//Assign BadgeDoor
                            doors = string.Join(",", updatebadge.DoorName); //Use join method to remove our doors one by one,from the same badge that we used before.
                            Console.WriteLine($"Badge #{updatebadge.BadgeId} has access to doors: {doors}.");//call my badge with its doors(if there are any)
                            Console.ForegroundColor = ConsoleColor.DarkRed;
                            Console.WriteLine("================================\n");
                            Console.ResetColor();
                            Console.WriteLine("Press any key to continue.");
                            Console.ReadKey();



                            break;
                        case "3":
                            KeepRunning = false;
                            break;
                    }

                }
                bool wasUpdate = _badgesrepo.UpdateBadges(ID, updatebadge);//Call my UpadteMethod from my repo
                if (wasUpdate == true)
                {
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.WriteLine("Your badge was successfuly updated\n");
                    Console.ResetColor();
                }
                else
                {
                    Console.WriteLine("Could not update the badge. Please try again.");
                }

            }
            else
            {
                Console.WriteLine("Please enter a valid ID");

            }
           
           

            

        }



        public void SeeDListOfBadges()
        {
            //Create lists for my doors
            List<string> listdoorsbadge1 = new List<string>();
            List<string> listdoorsbadge2 = new List<string>();
            List<string> listdoorsbadge3 = new List<string>();
            //Create my doors
            string a1 = "A1";
            string a2 = "A2";
            string b1 = "B1";
            string b2 = "B2";
            string b3= "B3";
            string c1 = "C1";


            // Add my doors to lists
            listdoorsbadge1.Add(a1);
            listdoorsbadge1.Add(a2);

            listdoorsbadge2.Add(b1);
            listdoorsbadge2.Add(b2);
            listdoorsbadge2.Add(b3);

            listdoorsbadge3.Add(c1);

            //Create my IDs
            int badgid1 = 1;
            _badges.BadgeId = badgid1;

            int badgid2 = 2;
            _badges.BadgeId = badgid2; 
            int badgid3 = 3;
            _badges.BadgeId = badgid1;

            //Call my CreateNewBadge and use badgid1 and  listdoorsbadge1 as a parameters. 
            _badgesrepo.CreateNewBadge(badgid1, listdoorsbadge1);
            _badgesrepo.CreateNewBadge(badgid2, listdoorsbadge2);
            _badgesrepo.CreateNewBadge(badgid3, listdoorsbadge3);



        }
    }
}
