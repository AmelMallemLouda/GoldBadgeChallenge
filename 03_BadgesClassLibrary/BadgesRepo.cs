using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_BadgesClassLibrary
{
    public class BadgesRepo
    {
        // Create a new Badge
       
           public  Dictionary<int, List<string>> _badges = new Dictionary<int, List<string>>();
           public List< Badges>badgelist = new List<Badges>();
           public Badges badges = new Badges();
          
        //Create
        public void AddNewBadge(int badgeid,List<string>doors)
        {
            _badges.Add(badgeid,doors); //adding a Key/Value using Add() method
          
          
        }
        
        //Read
        public Dictionary<int,List<string>> GetAllBadges()
        {
            return _badges;
        }
        //Update
        public bool UpdateBadges(int id,Badges newBadge)
        {
            Badges oldBadge = GetBadgeById(id);
            if (oldBadge != null) 
            {
                oldBadge.DoorName = newBadge.DoorName;
                oldBadge.DoorName = newBadge.DoorName;
               
                return true;
            }
            else
            {
                return false;
            }
        }
        
   

        public Badges GetBadgeById(int id)
        {
            foreach (Badges badge in badgelist)
            {
                if (badge.BadgeId == id)
                    return badge;
            }
            return null;


        }


    }
}
            
