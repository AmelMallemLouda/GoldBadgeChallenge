using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_ClaimsClassLibrary
{
    public class ClaimsRepo
    {
       private Queue< Claims> _listOfclaim = new Queue<Claims>();
        private Claims _claims = new Claims();

        //Create a claim
        public void AddClaimToList( Claims content)
        {
            _listOfclaim.Enqueue(content);
        }

        //View claims

        public Queue<Claims> GetAllClaims()
        {
            return _listOfclaim;
        }
       

        public void RemoveClaim(int id)
        {
            _listOfclaim.Dequeue();

  

        }

        public bool UpdateClaim(int id, Claims newClaim)
        {
            Claims oldClaim = GetClaimById(id);
            if (oldClaim != null)
            {
                oldClaim.ID = newClaim.ID;
                oldClaim.DateOfClaim = newClaim.DateOfClaim;
                oldClaim.TypeOfClaim = newClaim.TypeOfClaim;
                oldClaim.ClaimAmount = newClaim.ClaimAmount;
                oldClaim.DateOfIncident = newClaim.DateOfIncident;
                oldClaim.Description = newClaim.Description;
             
                return true;
            }
            else
            {
                return false;
            }
        }






        //Helper methods
        public Claims GetClaimById(int id)
        {
            foreach (Claims claim in _listOfclaim)
            {
                if (claim.ID == id)
                    return claim;
            }
            return null; 


        }
        

    }
}
