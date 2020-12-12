using _02_ClaimsClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_ClaimsConsoleApp
{
    public class ClaimsProgramUI
    {
        public Claims _claims = new Claims();
        public ClaimsRepo _claimsrepo = new ClaimsRepo();


        public void Run()
        {

            SeedContentList();

            Menu();
        }

        public void Menu()
        {

            bool KeepRunning = true;
            while (KeepRunning)
            {
                Console.WriteLine("Choose a menu item:\n" +
               "       " + "1.See all claims.\n" +
               "       " + "2.Take care of the next claim.\n" +
               "       " + "3.Enter a new claim.\n" +
               "       " + "4.Exit.");

                string input = Console.ReadLine();

                //Evaluate the user input and act accordingly
                Console.Clear();
                switch (input)
                {
                    case "1":
                        DisplayAllClaims();

                        break;
                    case "2":
                        DealWithClaim();
                      

                        break;
                    case "3":
                        CreateMenuClaim();
                        break;
                    case "4":
                        //Exit
                        Console.WriteLine("Goodbye");
                        KeepRunning = false;

                        break;

                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Please Enter a Valid Number.\n");
                        Console.ResetColor();
                        break;

                }
               
                Console.Clear();
            }

        }

        public void CreateMenuClaim()
        {
            Claims content = new Claims();

            Console.WriteLine("Enter the claim ID:");

            content.ID = int.Parse(Console.ReadLine());


            Console.WriteLine("Enter The Claim Type:\n" +
                "1.Car\n" +
                "2.Home\n" +
                "3.Theft\n");
            string typeAsString = Console.ReadLine();
            int TypeAsInt = int.Parse(typeAsString);
            content.TypeOfClaim = (ClaimType)TypeAsInt;

            Console.WriteLine("Enter The Claim Description:");
            content.Description = Console.ReadLine();

            Console.WriteLine("Enter Amount of Damage:");
            content.ClaimAmount = double.Parse(Console.ReadLine());


            Console.WriteLine("Enter The Date Of Accident:");
            content.DateOfIncident = DateTime.Parse(Console.ReadLine());

            Console.WriteLine("Enter The Date of Claim:");
            content.DateOfClaim = DateTime.Parse(Console.ReadLine());

 
            _claimsrepo.AddClaimToList(content);


        }

        




        public void DisplayAllClaims()
        {
            Queue<Claims> claims = _claimsrepo.GetAllClaims();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"{"ClaimID",-10}{"Type",-10}{"Description",-24}                  {"Amount",-15}{"DateOfAccident",-25}{"DateOfClaim",-25}{"IsValid",-15}");
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine("========================================================================================================================================");
            Console.ResetColor();

            foreach (Claims claim in claims)
            {
                Console.WriteLine($"{claim.ID,-10}{claim.TypeOfClaim,-10}{claim.Description,-25}                 ${claim.ClaimAmount,-15}{claim.DateOfIncident.ToShortDateString(),-25}{claim.DateOfClaim.ToShortDateString(),-25}{claim.IsValid,-15}");
            }

            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("Press any key to continue...");
            Console.ResetColor();

            Console.ReadKey();


        }
        //next in queue
        public void DealWithClaim()
        {
            Console.Clear();
            Console.WriteLine("The next claim is:");
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("==================");
            Console.ResetColor();
            Queue<Claims> newList = _claimsrepo.GetAllClaims();
              Claims nextClaim = newList.Peek();

            Console.WriteLine("     "+$"-ID: {nextClaim.ID}\n" +
               "     " +$"-Type: {nextClaim.TypeOfClaim}\n" +
                "     "+$"-Description: {nextClaim.Description}\n" +
                "     "+$"-Amount: ${nextClaim.ClaimAmount}\n" +
               "     "+$"-Incident Date: {nextClaim.DateOfIncident.ToShortDateString()}\n" +
                "     "+$"-Claim Date: {nextClaim.DateOfClaim.ToShortDateString()}\n" +
                "     "+$"-Valid: {nextClaim.IsValid}\n" +
                "     "+$"\n");

               
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("Would you like to deal with this claim?(Y/N)");
            Console.ResetColor();

           
            string Input = Console.ReadLine().ToLower();
            if (Input == "y")
            {

                newList.Dequeue();
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("You have successfully taken the claim\n" +
                    "Press any key to continue...");
                Console.ResetColor();
            }
            else
            { 
                    Menu();
                    
            }
                Console.ReadLine();
        }
      

   

        private void SeedContentList()
        {





            Claims claim1 = new Claims(1, ClaimType.Car, "Car accident on 465.",   400.0, DateTime.Parse("04/25/2019"), DateTime.Parse("04/25/2020"));
            Claims claim2 = new Claims(2, ClaimType.Home, "House fire in kitchen.",50000.00, DateTime.Parse("04/24/2020"), DateTime.Parse("04/25/2020"));
            Claims claim3 = new Claims(3, ClaimType.Theft, "Stolen pancakes.",     4.5, DateTime.Parse("04/25/2019"), DateTime.Parse("04/25/2020"));
            _claimsrepo.AddClaimToList(claim1); 
            _claimsrepo.AddClaimToList(claim2);
            _claimsrepo.AddClaimToList(claim3);

        }

       
    }


}
