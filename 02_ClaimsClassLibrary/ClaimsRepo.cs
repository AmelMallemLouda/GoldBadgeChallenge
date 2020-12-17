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
       

        //Create a claim
        public void CreateClaims( Claims content)
        {
            _listOfclaim.Enqueue(content);
        }

        //View claims

        public Queue<Claims> GetAllClaims()
        {
            return _listOfclaim;
        }
       

        public bool RemoveClaim(int id)
        {

            Claims claim = GetClaimById(id);
                if (claim == null)
                {
                   return false;
                }
            int initiallist = _listOfclaim.Count;
            _listOfclaim.Dequeue();
            if(initiallist> _listOfclaim.Count)
            {
                return true;
            }
            else
            {
                return false;
            }


  

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
