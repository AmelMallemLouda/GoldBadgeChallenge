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
           public List< Badges>badgesList = new List<Badges>();
          
        //Create
        public void AddNewBadge(int badgeid,List<string>doors)
        {
            _badges.Add(badgeid,doors); //adding a Key/Value using Add() method
          
          
        }
        //Create Door
        // public void CreatDoor(Badges door)
        //{
        //   List< Badges> newdoor = new List<Badges>();
        //    newdoor.Add(door);
        //}

        ////Delete Door

        //public void DeleteDoor(Badges door)
        //{
        //    List<Badges> deletedoor = new List<Badges>();
        //    deletedoor.Remove(door);

        //}
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
        //Delete
        
        public bool DeleteBadge(int badgeid)
        {

            Badges badgeDeleted = GetBadgeById(badgeid);
            if (badgeDeleted == null)
            {
               return false;
            }
            int initialCount = _badges.Count;
            _badges.Remove(badgeid);
            if (initialCount > _badges.Count)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        



        public Badges GetBadgeById(int id)
        {
            foreach (Badges badge in badgesList)
            {
                if (badge.BadgeId == id)
                    return badge;
            }
            return null;


        }


    }
}
            
