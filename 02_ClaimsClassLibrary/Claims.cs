using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_ClaimsClassLibrary
{
     public enum ClaimType { Car=1,Home,Theft}
    public class Claims
    {
        
        public int ID { get; set; }
        public ClaimType TypeOfClaim { get; set; }
        public string Description  { get; set; }
        public double ClaimAmount { get; set; }
        public DateTime DateOfIncident { get; set; }
        public DateTime DateOfClaim { get; set; }
        public bool IsValid 
        {
            get
            {

                if (DateOfClaim <= DateOfIncident.AddDays(30))
                {
                  
                    return true;
                

                }
                else
                   
                return false;
               
            }
        }
        




        public Claims() { }


        public Claims(int id, ClaimType typeofclaim, string description,double claimamount,DateTime dateofincident,DateTime dateofclaim)
        {
            ID = id;
            TypeOfClaim = typeofclaim;
            Description = description;
            ClaimAmount = claimamount;
            DateOfIncident = dateofincident;
            DateOfClaim = dateofclaim;
           
        }

      
    }
}
