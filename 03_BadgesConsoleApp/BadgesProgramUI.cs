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
        //public List<Door> doors = new List<Door>();
       //public Door _doors = new Door();
        public Badges _badges = new Badges();
        public BadgesRepo _badgesrepo = new BadgesRepo();
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
             Console.WriteLine("Choose a menu option:\n" +
                "1.Add a badge.\n" +
                "2.Edit a badge.\n" +
                "3.List all badges.\n");

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
                }
            Console.WriteLine("Press any Key to continue");
            Console.ReadKey();
            Console.Clear();
            }
        }

     


        public void AddNewBadgeToList()
        {

            List<string> doorlist = new List<string>();
            Badges badge = new Badges();

            Console.WriteLine("What is the number on the badge?\n");
            string stringAsInt = Console.ReadLine();
            badge.BadgeId = int.Parse(stringAsInt);
            //int id = Convert.ToInt32(Console.ReadLine());

            //badge.BadgeId = id;
            

            bool addingDoors = true;
            while (addingDoors)
            {
                Console.WriteLine("List a door that badge needs access to:\n");
                doorlist.Add(Console.ReadLine());

                Console.WriteLine("Any other doors this badge needs access to? Yes or No");
                string anyotherdoor = Console.ReadLine().ToLower();
               
                if (anyotherdoor == "no")
                {
                    addingDoors = false;
                    break;
                }
              

            }
            badge.DoorName = doorlist;
            _badgesrepo.AddNewBadge(badge.BadgeId, doorlist);

            Console.WriteLine("Press ENTER to return to Main Menu.");
            Console.ReadLine();
        }



    


        public void DisplayAllBadges()
        {

            Console.Clear();

            Dictionary<int, List<string>> dictionary = _badgesrepo.GetAllBadges();

            foreach (KeyValuePair<int, List<string>> keyvaluepair in dictionary)
            {

                // pull  int
                Console.WriteLine("\n");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Badge #" +" "+ keyvaluepair.Key + " "+ "has access to :");
                Console.ResetColor();

                Console.ForegroundColor = ConsoleColor.DarkGreen; 
                Console.WriteLine("================================\n");
                Console.ResetColor();
                //pull List<string>
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
           
            Console.WriteLine("What do you want to do ?\n" +
                "1.Add a door to a badge\n" + 
                "2.Remove a door to a badge");
            string input = Console.ReadLine();
            switch(input)
            {
                case "1":
                    AddDoorToBadge();
                    break;
            }
        }

        public void AddDoorToBadge()
        {
            List<Badges> door = new List<Badges>();
            Console.WriteLine("What is the badge number to update ? ");
            int badgeId = int.Parse(Console.ReadLine());
           Badges badge = _badgesrepo.GetBadgeById(badgeId);
          //Dictionary<int, string> adddoor = new Dictionary<int, string>();
            foreach(Badges badges in door)
            {
                door.Add(badges); 
            }
            
           

           // bool addingDoors = true;
           // while (addingDoors)
            //{
             //   Console.WriteLine("List a door that badge needs access to:\n");
             //   string input = (Console.ReadLine());
               // adddoor.Add(input);
                
             // badge.DoorName=adddoor ;

               


          //  }
           

          //  UpdateBadge();
        }
      

        public void SeeDListOfBadges()
        {

            List<string> listdoorsbadge1 = new List<string>();
            List<string> listdoorsbadge2 = new List<string>();
            List<string> listdoorsbadge3 = new List<string>();

            string a1 = "A1";
            string a2 = "A2";
            string b1 = "B1";
            string b2 = "B2";
            string b3= "B3";
            string c1 = "C1";
            listdoorsbadge1.Add(a1);
            listdoorsbadge1.Add(a2);

            listdoorsbadge2.Add(b1);
            listdoorsbadge2.Add(b2);
            listdoorsbadge2.Add(b3);
            listdoorsbadge3.Add(c1);

            int badgid1 = 1;
            _badges.BadgeId = badgid1;

            int badgid2 = 2;
            _badges.BadgeId = badgid2; 
            int badgid3 = 3;
            _badges.BadgeId = badgid1;


            _badgesrepo.AddNewBadge(badgid1, listdoorsbadge1);
            _badgesrepo.AddNewBadge(badgid2, listdoorsbadge2);
            _badgesrepo.AddNewBadge(badgid3, listdoorsbadge3);



        }
    }
}
