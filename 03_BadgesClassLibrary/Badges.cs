using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_BadgesClassLibrary
{
    public class Badges
    {
        public int BadgeId { get; set; }
        public List<string> DoorName { get; set; } 




        public Badges() { }
        // Create a constructor with int as a parameter to use that later for GetBadgeById method. 
        public Badges(int id)
        {
            BadgeId = id;
        }

        public Badges(int badgesid, List<string> doorname )
        {
            BadgeId = badgesid;
            DoorName = doorname;
           
          
            
        }

        



    }
}
